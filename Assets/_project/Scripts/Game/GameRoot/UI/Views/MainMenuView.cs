using UnityEngine;
using UnityEngine.UI;

namespace _project.Scripts.Game.GameRoot.UI
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button startGameButton;
        public Button StartGameButton => startGameButton;

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