using _project.Scripts.Game.GameRoot;
using _project.Scripts.Services;
using _project.Scripts.Tools;
using Zenject;

namespace _project.Scripts.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<UIRootView>().FromComponentInNewPrefabResource(Constants.Paths.UiRootViewPath).AsSingle().NonLazy();
            

            Container.Bind<SceneLoaderService>().AsSingle();
            Container.Bind<ResourceLoaderService>().AsSingle();
            Container.Bind<GameFactory>().AsSingle();

        }
    }
}