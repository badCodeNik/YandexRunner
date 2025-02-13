using _project.Scripts.Game.GameRoot;
using _project.Scripts.Services;

namespace _project.Scripts.Game.Infrastructure
{
    public class GameStarter
    {
        public GameStarter(GameplayInitializer gameplayInitializer)
        {
            var uiRootView = AllServices.Container.Single<UIRootView>();
            uiRootView.MainMenuView.StartGameButton.onClick.AddListener(gameplayInitializer.StartGameplay);
            uiRootView.MainMenuView.StartGameButton.onClick.AddListener(uiRootView.ShowHud);
            //uiRootView.LosePanelView.MainMenuButton.onClick.AddListener();
            //uiRootView.LosePanelView.RestartLevelButton.onClick.AddListener();
            //uiRootView.WinPanelView.MainMenuButton.onClick.AddListener();
            //uiRootView.WinPanelView.NextLevelButton.onClick.AddListener();
        }
    }
}