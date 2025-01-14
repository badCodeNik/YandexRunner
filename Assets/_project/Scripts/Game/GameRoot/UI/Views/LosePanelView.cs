using UnityEngine;
using UnityEngine.UI;

namespace _project.Scripts.Game.GameRoot.UI.Views
{
    public class LosePanelView : MonoBehaviour
    {
        public Button RestartLevelButton => restartLevelButton;
        public Button MainMenuButton => mainMenuButton;

        [SerializeField] private Button restartLevelButton;
        [SerializeField] private Button mainMenuButton;


        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}