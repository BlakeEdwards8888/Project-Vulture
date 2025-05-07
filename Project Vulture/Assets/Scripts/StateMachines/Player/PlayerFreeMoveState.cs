using Input;
using Platformer.Movement;
using UnityEngine;

namespace StateMachines.Player
{
    public class PlayerFreeMoveState : PlayerBaseState
    {
        readonly int IdleHash = Animator.StringToHash("Idle");

        public PlayerFreeMoveState(PlayerStateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            stateMachine.Animator.Play(IdleHash);
            stateMachine.InputReader.jumpEvent += stateMachine.Jumper.Jump;
            stateMachine.InputReader.jumpCanceledEvent += stateMachine.Jumper.CancelJump;
            stateMachine.InputReader.attackEvent += Attack;
        }

        public override void Execute(float deltaTime)
        {
            FaceMovementDirection();

            Vector2 inputValue = stateMachine.InputReader.MovementValue;

            if(stateMachine.GroundChecker.IsGrounded() && inputValue.y < -InputValueBuffer)
            {
                stateMachine.SwitchState(new PlayerCrouchState(stateMachine));
            }
        }

        public override void ExecuteFixed(float deltaTime)
        {
            stateMachine.Mover.Move(stateMachine.InputReader.MovementValue.x);
        }

        public override void Exit()
        {
            stateMachine.InputReader.jumpEvent -= stateMachine.Jumper.Jump;
            stateMachine.InputReader.jumpCanceledEvent -= stateMachine.Jumper.CancelJump;
            stateMachine.InputReader.attackEvent -= Attack;
        }

        void Attack()
        {
            stateMachine.SwitchState(new PlayerStandingAttackState(stateMachine));
        }
    }
}
