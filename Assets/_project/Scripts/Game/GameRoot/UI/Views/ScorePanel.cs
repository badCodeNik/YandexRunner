using _project.Scripts.Services.Services;
using TMPro;
using UnityEngine;

namespace _project.Scripts.Game.GameRoot.UI.Views
{
    public class ScorePanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;
        
        
        private void Update()
        {
            var fullScore = Mathf.Round(ScoreService.Instance.Score);
            scoreText.text =  fullScore.ToString();
        }

        public void ShowScore()
        {
            gameObject.SetActive(true);
        }

        public void HideScore()
        {
            gameObject.SetActive(false);
        }

    }
}