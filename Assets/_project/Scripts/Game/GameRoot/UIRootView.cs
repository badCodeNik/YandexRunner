using _project.Scripts.Game.Configs;
using _project.Scripts.Game.GameRoot.UI;
using _project.Scripts.Game.GameRoot.UI.Views;
using _project.Scripts.Tools;
using UnityEngine;

namespace _project.Scripts.Game.GameRoot
{
    public class UIRootView : MonoBehaviour
    {
        public LosePanelView LosePanelView => losePanelView;
        public WinPanelView WinPanelView => winPanelView;
        public MainMenuView MainMenuView => mainMenuView;
        
        [SerializeField] private GameObject loadingScreen;
        [SerializeField] private MainMenuView mainMenuView;
        [SerializeField] private TapPanelView tapPanelView;
        [SerializeField] private LosePanelView losePanelView;
        [SerializeField] private WinPanelView winPanelView;
        [SerializeField] private WordChoicePanel wordChoicePanel;
        [SerializeField] private ScorePanel scorePanel;


        private bool _tapPanelIsActive;
        private Signal _signal;


        private void Awake()
        {
            loadingScreen.SetActive(false);
        }

        public void Initialize(Signal signal)
        {
            _signal = signal;
            wordChoicePanel.Initialize(_signal);
        }

        #region WinPanel

        public void ShowWinPanel()
        {
            winPanelView.Show();
        }

        public void HideWinPanel()
        {
            winPanelView.Hide();
        }

        #endregion

        #region LosePanel

        public void ShowLosePanel()
        {
            losePanelView.Show();
        }

        public void HideLosePanel()
        {
            losePanelView.Hide();
        }

        #endregion

        #region MainMenu

        public void ShowMainMenuPanel()
        {
            mainMenuView.Show();
        }

        public void HideMainMenuPanel()
        {
            mainMenuView.Hide();
        }

        #endregion

        #region LoadingScreen

        public void ShowLoadingScreen()
        {
            loadingScreen.SetActive(true);
        }

        public void HideLoadingScreen()
        {
            loadingScreen.SetActive(false);
        }

        #endregion

        #region TapPanel

        public void ShowTapPanel()
        {
            tapPanelView.Show();
            _tapPanelIsActive = true;
        }

        private void HideTapPanel()
        {
            tapPanelView.Hide();
            _tapPanelIsActive = false;
            _signal.RegistryRaise(new GameSignals.OnGameStarted());
        }

        private void Update()
        {
            if (_tapPanelIsActive && Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                {
                    if (touch.phase == TouchPhase.Began) HideTapPanel();
                }
            }

#if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0) && _tapPanelIsActive)
            {
                HideTapPanel();
            }
#endif
        }

        #endregion
        
        #region ScorePanel

        public void ActivateScore()
        {
            scorePanel.ShowScore();
        }
        public void HideScore()
        {
            scorePanel.HideScore();
        }
        
        #endregion
    }
}