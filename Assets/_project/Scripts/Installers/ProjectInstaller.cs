using System;
using _project.Scripts.Game.GameRoot;
using _project.Scripts.Game.Infrastructure;
using _project.Scripts.Game.Infrastructure.FSM;
using _project.Scripts.GoogleImporter;
using _project.Scripts.Services;
using _project.Scripts.Services.Input;
using _project.Scripts.Tools;
using GoogleImporter;
using Zenject;

namespace _project.Scripts.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameStateMachine>().AsSingle();
            Container.Bind<Game.Infrastructure.FSM.Game>().AsSingle().NonLazy();
            
            Container.Bind<ILevelState>().To<InitializeGameState>().AsTransient();
            Container.Bind<ILevelState>().To<LoadLevelState>().AsTransient();
            
            Container.Bind<SceneLoaderService>().AsSingle();
            Container.Bind<ResourceLoaderService>().AsSingle();
            Container.Bind<GameFactory>().AsSingle();
            Container.Bind<InputService>().AsSingle();
            
            Container.Bind<Signal>().AsSingle();
            Container.Bind<UIRootView>().FromComponentInNewPrefabResource(Constants.Paths.UiRootViewPath).AsSingle().NonLazy();
            Container.Bind<Config>().AsSingle();
            Container.BindInterfacesAndSelfTo<GoogleParser>().AsSingle();
            Container.Bind<GoogleSheetsImporter>().AsSingle();
            
            Container.Bind<GameplayInitializer>().AsSingle();
            Container.Bind<GameStarter>().AsSingle();
            
            
        }
    }
}