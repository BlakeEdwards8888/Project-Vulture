using UnityEngine;

namespace StateMachines
{
    public abstract class StateMachine
    {
        State currentState;

        public void SwitchState(State newState)
        {
            currentState?.Exit();
            currentState = newState;
            currentState?.Enter();
        }

        void Update()
        {
            currentState?.Execute(Time.deltaTime);
        }

        private void OnDestroy()
        {
            currentState?.Exit();
        }
    }
}
