using System;
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
            Container.Bind<Signal>().AsSingle().WithArguments(true);
            Container.Bind<Game.Infrastructure.FSM.Game>().AsSingle();
            Container.Bind<GameStateMachine>().AsSingle();
            Container.Bind<ILevelState>().To<InitializeGameState>().WhenInjectedInto<GameStateMachine>();
            Container.Bind<ILevelState>().To<LoadLevelState>().WhenInjectedInto<GameStateMachine>();
            Container.Bind<IDisposable>().To<InputService>().AsSingle();
            Container.Bind<ResourceLoaderService>().AsSingle();
            Container.Bind<GameFactory>().AsSingle();
            Container.Bind<Config>().AsSingle();
            Container.BindInterfacesAndSelfTo<GoogleParser>().AsSingle();
            Container.Bind<GoogleSheetsImporter>().AsSingle();
        }
    }
}