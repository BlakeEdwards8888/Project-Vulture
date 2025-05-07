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

        private Vector2 CalculateMoveDirection()
        {
            float x = 0;

            if (stateMachine.InputReader.MovementValue.x > InputValueBuffer)
            {
                x = 1;
            }
            else if (stateMachine.InputReader.MovementValue.x < -InputValueBuffer)
            {
                x = -1;
            }

            return new Vector2(x, 0);
        }

        protected void FaceMovementDirection()
        {
            Vector2 movementDirection = CalculateMoveDirection();

            if (movementDirection.x < 0)
            {
                stateMachine.transform.localScale = new Vector3(-0.5f, 1, 1);
            }
            else if (movementDirection.x > 0)
            {
                stateMachine.transform.localScale = new Vector3(0.5f, 1, 1);
            }
        }
    }
}
