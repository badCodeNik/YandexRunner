using System;
using _project.Scripts.Game.Configs;
using _project.Scripts.Game.Entities;
using UnityEngine;

namespace _project.Scripts.Game
{
    public abstract class GameSignals
    {
        public struct OnGameStarted
        {
        }

        public struct OnGameEnded
        {
            public bool HasWon;
        }

        public struct OnHeroSpawned
        {
            public Hero Hero;
        }
        
        public struct QuizStarted { }

        public struct OnConfigUpdated
        {
            public WordConfig Config;
        }

        public struct OnTriggerEntered
        {
            public Action Action;
        }
    }
}