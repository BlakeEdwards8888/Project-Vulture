using Input;
using Platformer.Movement;
using UnityEngine;

namespace StateMachines.Player
{
    public class PlayerStateMachine : StateMachine
    {
        public InputReader InputReader => GetComponent<InputReader>();
        public Mover Mover => GetComponent<Mover>();
        public Jumper Jumper => GetComponent<Jumper>();
        public GroundChecker GroundChecker => GetComponent<GroundChecker>();
        public Animator Animator => GetComponent<Animator>();

        private void Start()
        {
            SwitchState(new PlayerFreeMoveState(this));
        }
    }
}
