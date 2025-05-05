using UnityEngine;

namespace StateMachines.Player
{
    public abstract class PlayerBaseState : State
    {
        protected const float InputValueBuffer = 0.2f;

        protected PlayerStateMachine stateMachine;

        public PlayerBaseState(PlayerStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        protected void Move(float direction)
        {
            stateMachine.Mover.Move(direction);
        }
    }
}
