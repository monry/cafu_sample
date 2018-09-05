using System;
using System.Collections.Generic;
using Monry.CAFUSample.UseCase;
using UniRx;
using Zenject;

namespace Monry.CAFUSample.Presentation.Presenter
{
    public class MolePresenter : IMolePresenter
    {
        [Inject] private PlaceholderFactory<int, IMoleView> MoleViewFactory { get; }

        private List<IMoleView> MoleViewList { get; } = new List<IMoleView>();

        public void Instantiate(int index)
        {
            MoleViewList.Add(MoleViewFactory.Create(index));
        }

        public void Show(int index)
        {
            MoleViewList[index].Show();
        }

        public void Hide(int index)
        {
            MoleViewList[index].Hide();
        }

        public void Feint(int index)
        {
            MoleViewList[index].Feint();
        }

        public void Hit(int index)
        {
            MoleViewList[index].Hit();
        }

        public bool CanAttack(int index)
        {
            return MoleViewList[index].CanAttack();
        }

        public void Activate(int index)
        {
            MoleViewList[index].Activate();
        }

        public void Deactivate(int index)
        {
            MoleViewList[index].Deactivate();
        }

        public IObservable<Unit> AttackAsObservable(int index)
        {
            return MoleViewList[index].AttackAsObservable();
        }

        public IObservable<Unit> WillShowAsObservable(int index)
        {
            return MoleViewList[index].WillShowAsObservable();
        }

        public IObservable<Unit> WillHideAsObservable(int index)
        {
            return MoleViewList[index].WillHideAsObservable();
        }

        public IObservable<Unit> WillFeintAsObservable(int index)
        {
            return MoleViewList[index].WillFeintAsObservable();
        }

        public IObservable<Unit> WillHitAsObservable(int index)
        {
            return MoleViewList[index].WillHitAsObservable();
        }

        public IObservable<Unit> DidShowAsObservable(int index)
        {
            return MoleViewList[index].DidShowAsObservable();
        }

        public IObservable<Unit> DidHideAsObservable(int index)
        {
            return MoleViewList[index].DidHideAsObservable();
        }

        public IObservable<Unit> DidFeintAsObservable(int index)
        {
            return MoleViewList[index].DidFeintAsObservable();
        }

        public IObservable<Unit> DidHitAsObservable(int index)
        {
            return MoleViewList[index].DidHitAsObservable();
        }
    }
}