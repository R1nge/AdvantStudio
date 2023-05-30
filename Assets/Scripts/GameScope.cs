using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameScope : LifetimeScope
{
    [SerializeField] private ScoreHandler scoreHandler;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<GameManager>(Lifetime.Singleton).AsSelf();
        builder.RegisterComponent(scoreHandler);
    }
}