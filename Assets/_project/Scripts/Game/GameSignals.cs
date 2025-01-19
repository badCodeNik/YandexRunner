using System;
using _project.Scripts.Game.Entities;
using _project.Scripts.GoogleImporter;
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
            public bool hasWon;
        }

        public struct OnHeroSpawned
        {
            public Hero Hero;
        }
        
        public struct QuizStarted { }

        public struct OnConfigUpdated
        {
            public Config Config;
        }

        public struct OnTriggerEntered
        {
            public Action Action;
        }
    }
}