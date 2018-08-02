using System;
using System.Collections.Generic;
using System.Linq;
using Monry.CAFUSample.Application;
using Monry.CAFUSample.Domain.UseCase;
using Monry.CAFUSample.Presentation.Presenter.Interface;
using Presentation.Presenter.Interface;
using UniRx;
using Zenject;

namespace Monry.CAFUSample.Presentation.Presenter
{
    public class GamePresenter :
        IMoleSpawnablePresenter,
        IGameFinishNotifyablePresenter,
        IGameScoreRenderablePresenter,
        IGameStateHandlerPresenter
    {
        [Inject] private DiContainer Container { get; }

        [Inject] private IScoreView ScoreView { get; }

        [Inject] private IGameStateStartHandlerView GameStateStartHandlerView { get; }

        private List<IMoleView> MoleViewList { get; } = new List<IMoleView>();

        public void RenderScore(int score)
        {
            ScoreView.Render(score);
        }

        public void ShowMole(int index)
        {
            throw new NotImplementedException();
        }

        public void HideMole(int index)
        {
            throw new NotImplementedException();
        }

        public IObservable<Unit> OnShowMoleAsObservable(int index)
        {
            throw new NotImplementedException();
        }

        public IObservable<Unit> OnHideMoleAsObservable(int index)
        {
            throw new NotImplementedException();
        }

        public void SpawnMoles(int amount = Constant.MoleAmount)
        {
            foreach (var index in Enumerable.Range(0, amount))
            {
                var mole = Container.Resolve<IMoleView>();
                mole.Index = index;
                MoleViewList.Add(mole);
            }
        }

        public IObservable<Unit> OnStartAsObservable()
        {
            return GameStateStartHandlerView.OnGameStartAsObservable();
        }

        public IObservable<Unit> OnStopAsObservable()
        {
            return Observable.Empty<Unit>();
        }

        public IObservable<Unit> OnResumeAsObservable()
        {
            return Observable.Empty<Unit>();
        }

        public IObservable<Unit> OnPauseAsObservable()
        {
            return Observable.Empty<Unit>();
        }

        public void OnGameFinished()
        {
            UnityEngine.Debug.Log("GameFinished!!!");
        }
    }
}