using _project.Scripts.GoogleImporter;
using _project.Scripts.Tools;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _project.Scripts.Game.GameRoot.UI
{
    public class WordChoicePanel : MonoBehaviour
    {
        [SerializeField] private GameObject panel;
        [SerializeField] private Button firstChoice;
        [SerializeField] private Button secondChoice;
        [SerializeField] private Button thirdChoice;
        [SerializeField] private TMP_Text term;
        [SerializeField] private TMP_Text firstTranslation;
        [SerializeField] private TMP_Text secondTranslation;
        [SerializeField] private TMP_Text thirdTranslation;
        private UISignals.OnTranslationChosen _firstSignal;
        private UISignals.OnTranslationChosen _secondSignal;
        private UISignals.OnTranslationChosen _thirdSignal;
        private Signal _signal;


        private void Start()
        {
            firstChoice.onClick.AddListener(FirstButtonClicked);
            secondChoice.onClick.AddListener(SecondButtonClicked);
            thirdChoice.onClick.AddListener(ThirdButtonClicked);
        }

        [Inject]
        public void Construct(Signal signal)
        {
            _signal = signal;
            _signal.Subscribe<GameSignals.QuizStarted>(OnSignal);
        }


        private void FirstButtonClicked()
        {
            panel.SetActive(false);
            _signal.RegistryRaise(_firstSignal);
        }

        private void SecondButtonClicked()
        {
            panel.SetActive(false);
            _signal.RegistryRaise(_secondSignal);
        }

        private void ThirdButtonClicked()
        {
            panel.SetActive(false);
            _signal.RegistryRaise(_thirdSignal);
        }

        private void OnSignal(GameSignals.QuizStarted data)
        {
            var combination = ServiceLocator.Instance.GetInstance<Config>().GetRandomCombination();
            term.text = combination.Item1;
            firstTranslation.text = combination.Item2[0];

            _firstSignal = new UISignals.OnTranslationChosen
            {
                ChosenTranslation = combination.Item2[0],
                RightAnswer = combination.Item2[3]
            };
            secondTranslation.text = combination.Item2[1];

            _secondSignal = new UISignals.OnTranslationChosen
            {
                ChosenTranslation = combination.Item2[1],
                RightAnswer = combination.Item2[3]
            };

            thirdTranslation.text = combination.Item2[2];

            _thirdSignal = new UISignals.OnTranslationChosen
            {
                ChosenTranslation = combination.Item2[2],
                RightAnswer = combination.Item2[3]
            };

            panel.SetActive(true);
        }
    }
}