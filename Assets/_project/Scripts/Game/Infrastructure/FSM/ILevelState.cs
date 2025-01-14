using UnityEngine;

namespace _project.Scripts.Game.Infrastructure.FSM
{
    public interface ILevelState
    {
        void Enter();
        void Exit();
    }
    
}