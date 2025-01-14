using UnityEngine;
using UnityEngine.UI;

namespace _project.Scripts.Game.GameRoot.UI.Views
{
    public class WinPanelView : MonoBehaviour
    {
        public Button MainMenuButton => mainMenuButton;
        public Button NextLevelButton => nextLevelButton;

        [SerializeField] private Button mainMenuButton;
        [SerializeField] private Button nextLevelButton;

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }
    }
}