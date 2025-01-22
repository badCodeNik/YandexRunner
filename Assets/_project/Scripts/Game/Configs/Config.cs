using UnityEngine;

namespace _project.Scripts.Game.Configs
{
    public abstract class Config : ScriptableObject
    {
        public abstract void Initialize();
    }
}