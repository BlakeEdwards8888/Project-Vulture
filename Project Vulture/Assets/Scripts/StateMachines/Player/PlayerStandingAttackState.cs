using UnityEngine;

namespace StateMachines.Player
{
    public class PlayerStandingAttackState : PlayerBaseState
    {
        readonly int AttackHash = Animator.StringToHash("StandingAttack");

        public PlayerStandingAttackState(PlayerStateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            stateMachine.Animator.Play(AttackHash);
        }

        public override void Execute(float deltaTime)
        {
            AnimatorStateInfo anim = stateMachine.Animator.GetCurrentAnimatorStateInfo(0);

            if (anim.IsTag("Attack") && anim.normalizedTime >= 1)
            {
                stateMachine.SwitchState(new PlayerFreeMoveState(stateMachine));
            }
        }

        public override void ExecuteFixed(float deltaTime)
        {
            if(stateMachine.GroundChecker.IsGrounded())
            stateMachine.Mover.Move(0);
        }

        public override void Exit()
        {
            
        }
    }
}
