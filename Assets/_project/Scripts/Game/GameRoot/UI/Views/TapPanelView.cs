using UnityEngine;

namespace _project.Scripts.Game.GameRoot.UI
{
    public class TapPanelView : MonoBehaviour
    {
        public void Show() => 
            gameObject.SetActive(true);

        public void Hide() => 
            gameObject.SetActive(false);
    }
}