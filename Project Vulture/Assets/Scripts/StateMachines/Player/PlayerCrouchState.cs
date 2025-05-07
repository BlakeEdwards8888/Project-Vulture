using UnityEngine;

namespace StateMachines.Player
{
    public class PlayerCrouchState : PlayerBaseState
    {
        readonly int CrouchHash = Animator.StringToHash("Crouch");

        public PlayerCrouchState(PlayerStateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            stateMachine.Animator.Play(CrouchHash);
            stateMachine.InputReader.attackEvent += Attack;
        }

        public override void Execute(float deltaTime)
        {
            FaceMovementDirection();

            Vector2 inputValue = stateMachine.InputReader.MovementValue;

            if(inputValue.y >= 0)
            {
                stateMachine.SwitchState(new PlayerFreeMoveState(stateMachine));
            }
        }

        public override void ExecuteFixed(float deltaTime)
        {
            stateMachine.Mover.Move(0);
        }

        public override void Exit()
        {
            stateMachine.InputReader.attackEvent -= Attack;
        }

        void Attack()
        {
            stateMachine.SwitchState(new PlayerCrouchAttackState(stateMachine));
        }
    }
}
