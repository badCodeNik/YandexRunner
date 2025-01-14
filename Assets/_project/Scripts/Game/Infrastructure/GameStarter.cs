using _project.Scripts.Game.GameRoot;

namespace _project.Scripts.Game.Infrastructure
{
    public class GameStarter
    {
        public GameStarter(UIRootView uiRootView, GameplayInitializer gameplayInitializer)
        {
            uiRootView.MainMenuView.StartGameButton.onClick.AddListener(gameplayInitializer.StartGameplay);
            //uiRootView.LosePanelView.MainMenuButton.onClick.AddListener();
            //uiRootView.LosePanelView.RestartLevelButton.onClick.AddListener();
            //uiRootView.WinPanelView.MainMenuButton.onClick.AddListener();
            //uiRootView.WinPanelView.NextLevelButton.onClick.AddListener();
        }
    }
    
}