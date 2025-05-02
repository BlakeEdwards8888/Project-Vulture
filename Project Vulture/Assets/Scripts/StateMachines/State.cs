using UnityEngine;

namespace StateMachines
{
    public abstract class State
    {
        public abstract void Enter();
        public abstract void Execute(float deltaTime);
        public abstract void Exit();
    }
}
