using UnityEngine;

namespace StateMachines
{
    public abstract class StateMachine : MonoBehaviour
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

        private void FixedUpdate()
        {
            currentState?.ExecuteFixed(Time.deltaTime);
        }

        private void OnDestroy()
        {
            currentState?.Exit();
        }
    }
}
