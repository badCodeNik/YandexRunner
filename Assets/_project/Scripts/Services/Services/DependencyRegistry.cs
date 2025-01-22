using _project.Scripts.Game.Configs;
using _project.Scripts.Game.GameplayControllers;
using _project.Scripts.Game.GameRoot;
using _project.Scripts.Game.Infrastructure.FSM;
using _project.Scripts.Tools;
using GoogleImporter;

namespace _project.Scripts.Services.Services
{
    public static class DependencyRegistry
    {
        public static void RegisterDependencies(Signal signal,
            UIRootView uiRootView,
            IGoogleSheetParser parser,
            GoogleSheetsImporter googleSheetsImporter,
            ResourceLoaderService resourceLoaderService,
            CameraController cameraController,
            CompositionRoot compositionRoot)
        {
            AllServices.Container.RegisterSingle(signal);
            AllServices.Container.RegisterSingle(uiRootView);
            AllServices.Container.RegisterSingle(parser);
            AllServices.Container.RegisterSingle(googleSheetsImporter);
            AllServices.Container.RegisterSingle(resourceLoaderService);
            AllServices.Container.RegisterSingle(new SceneLoaderService());
            AllServices.Container.RegisterSingle(new GameFactory(resourceLoaderService));
            AllServices.Container.RegisterSingle(cameraController);
            AllServices.Container.RegisterSingle(compositionRoot);
        }
    }
}