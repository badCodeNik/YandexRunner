using _project.Scripts.Extentions;
using _project.Scripts.Game;
using _project.Scripts.Game.Configs;
using _project.Scripts.Tools;

namespace _project.Scripts.Services.Services
{
    public class ScoreService : Singleton<ScoreService>
    {
        private float _scoreMultiplier;
        private Signal _signal;
        public float Score { get; private set; }


        public static void Initialize(Signal signal)
        {
            Instance._signal = signal;
            signal.Subscribe<GameSignals.OnGameStarted>(GetData);
        }

        private static void GetData(GameSignals.OnGameStarted data)
        {
            Instance._scoreMultiplier = AllServices.Container.Single<GameplayConfig>().ScoreMultiplier;
        }

        public static void CountScore(float distance)
        {
            Instance.Score += distance * Instance._scoreMultiplier;
        }
    }
}