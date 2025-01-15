using _project.Scripts.Game.GameRoot;
using _project.Scripts.Game.Infrastructure.FSM;
using _project.Scripts.Services;
using _project.Scripts.Tools;
using Zenject;

namespace _project.Scripts.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Signal>().AsSingle();
            Container.Bind<UIRootView>().FromComponentInNewPrefabResource(Constants.Paths.UiRootViewPath).AsSingle().NonLazy();
            Container.Bind<GameStateMachine>().AsSingle();
            Container.Bind<ILevelState>().To<InitializeGameState>().WhenInjectedInto<GameStateMachine>();
            Container.Bind<ILevelState>().To<LoadLevelState>().WhenInjectedInto<GameStateMachine>();

            Container.Bind<SceneLoaderService>().AsSingle();
            Container.Bind<ResourceLoaderService>().AsSingle();
            Container.Bind<GameFactory>().AsSingle();

        }
    }
}