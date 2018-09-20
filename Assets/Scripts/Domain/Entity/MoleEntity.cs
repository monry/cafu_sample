using System;
using System.Collections.Generic;
using CAFU.Core;
using ExtraLinq;
using ExtraUniRx;
using Monry.CAFUSample.Application;
using UniRx;
using Zenject;

namespace Monry.CAFUSample.Domain.Entity
{
    public interface IMoleEntity : IEntity
    {
        int Index { get; }
        ISubject<Unit> ActivateSubject { get; }
        ISubject<Unit> DeactivateSubject { get; }
        ITenseSubject ShowSubject { get; }
        ITenseSubject HideSubject { get; }
        ITenseSubject FeintSubject { get; }
        ITenseSubject HitSubject { get; }

        ITenseSubject<int> AttackSubject { get; }

        void Start();
        void Finish();
    }

    public class MoleEntity : IMoleEntity
    {
        private static readonly Dictionary<string, Func<IMoleEntity, ITenseSubject>> NextActionMap = new Dictionary<string, Func<IMoleEntity, ITenseSubject>>
        {
            {Constant.Animator.AnimationStateName.Show, x => x.ShowSubject},
            {Constant.Animator.AnimationStateName.Feint, x => x.FeintSubject},
        };

        public int Index { get; }
        public ISubject<Unit> ActivateSubject { get; } = new Subject<Unit>();
        public ISubject<Unit> DeactivateSubject { get; } = new Subject<Unit>();
        public ITenseSubject ShowSubject { get; } = new TenseSubject();
        public ITenseSubject HideSubject { get; } = new TenseSubject();
        public ITenseSubject FeintSubject { get; } = new TenseSubject();
        public ITenseSubject HitSubject { get; } = new TenseSubject();

        public ITenseSubject<int> AttackSubject { get; } = new TenseSubject<int>();

        private bool CanAttack { get; set; }
        private IDisposable DidActiveDisposable { get; set; }
        private IDisposable DidInactiveDisposable { get; set; }

        public void Start()
        {
            DeactivateSubject.OnNext(Unit.Default);
        }

        public void Finish()
        {
            ShowSubject.OnCompleted();
            HideSubject.OnCompleted();
            FeintSubject.OnCompleted();
            HitSubject.OnCompleted();
            DidActiveDisposable?.Dispose();
            DidInactiveDisposable?.Dispose();
        }

        public MoleEntity(int index)
        {
            Index = index;
        }

        [Inject]
        public void Initialize()
        {
            // 有効になった後
            DidActiveDisposable = ActivateSubject
                // 受付時間が経過した後
                .SelectMany(_ => Observable.Timer(TimeSpan.FromSeconds(Constant.MoleActiveDuration)))
                // まだ攻撃が有効な場合
                .Where(_ => CanAttack)
                // 非表示にする
                .Subscribe(_ => HideSubject.Do());
            // 無効になった後
            DidInactiveDisposable = DeactivateSubject
                // ランダムに待った後
                .SelectMany(_ => Observable.Timer(TimeSpan.FromSeconds(UnityEngine.Random.Range(Constant.MoleInactiveDurationFrom, Constant.MoleInactiveDurationTo))))
                // 次の処理をランダムに決定して実行
                .Subscribe(_ => NextActionMap.Random().Value(this).Do());

            ActivateSubject.Subscribe(_ => CanAttack = true);
            DeactivateSubject.Subscribe(_ => CanAttack = false);

            // 表示が終わったら当たり判定を有効にする
            ShowSubject.WhenDid().Subscribe(_ => ActivateSubject.OnNext(Unit.Default));
            // 消去が始まったら当たり判定を無効にする
            HideSubject.WhenWill().Subscribe(_ => DeactivateSubject.OnNext(Unit.Default));
            // 攻撃が始まったら当たり判定を無効にする
            AttackSubject.WhenWill().Subscribe(_ => DeactivateSubject.OnNext(Unit.Default));
            AttackSubject.WhenDid().Subscribe(_ => HitSubject.Do());
        }
    }
}