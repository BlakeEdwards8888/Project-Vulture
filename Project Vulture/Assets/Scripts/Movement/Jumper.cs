using Input;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Movement
{
    public class Jumper : MonoBehaviour
    {
        [SerializeField] float jumpForce;
        [Range(0,1)]
        [SerializeField] float jumpCancelMultiplier;

        Rigidbody2D rb2d;
        GroundChecker groundChecker;

        private void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
            groundChecker = GetComponent<GroundChecker>();
        }

        public void Jump()
        {
            if (groundChecker.IsGrounded() || (groundChecker.IsCoyoteTime() && rb2d.linearVelocity.y <= 0))
            {
                rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, 0);
                rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }

        public void CancelJump()
        {
            if(rb2d.linearVelocity.y > 0)
            {
                rb2d.AddForce(Vector2.down * rb2d.linearVelocity.y * (1 - jumpCancelMultiplier), ForceMode2D.Impulse);
            }
        }
    }
}
