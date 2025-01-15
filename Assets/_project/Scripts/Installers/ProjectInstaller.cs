using _project.Scripts.Services;
using _project.Scripts.Services.Input;
using _project.Scripts.Tools;
using Zenject;

namespace _project.Scripts.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Signal>().AsSingle();
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle();
            Container.Bind<ResourceLoaderService>().AsSingle();
            Container.Bind<GameFactory>().AsSingle();
        }
    }
}