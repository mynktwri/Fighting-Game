using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class PlatformerCharacter2D : MonoBehaviour
    {
        private float life = 10f;
        private float defMod = 1f;
        private float speedMod = 1f;
        private float jumpMod = 1f;
        private float comboMeter = 0f; //where 3.0 would be fully charged



        [SerializeField] private float MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
        [SerializeField] private float JumpForce = 400f;                  // Amount of force added when the player jumps.
        [Range(0, 1)] [SerializeField] private float CrouchSpeed = .36f;  // Amount of maxSpeed applied to crouching movement. 1 = 100%
        [SerializeField] private bool AirControl = false;                 // Whether or not a player can steer while jumping;
        [SerializeField] private LayerMask WhatIsGround;                  // A mask determining what is ground to the character

        private Transform GroundCheck;    // A position marking where to check if the player is grounded.
        const float GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
        private bool Grounded;            // Whether or not the player is grounded.
        private Transform CeilingCheck;   // A position marking where to check for ceilings
        const float CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
        private Animator Anim;            // Reference to the player's animator component.
        private Rigidbody2D rb;
        private bool FacingRight = true;  // For determining which way the player is currently facing.

        private void Awake()
        {
            // Setting up references.
            GroundCheck = transform.Find("GroundCheck");
            CeilingCheck = transform.Find("CeilingCheck");
            Anim = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();

            //TODO: attach life variable to health bar
            //      attach combo variable to combo bar
            //set up base stats
            life = life * defMod;
            MaxSpeed = MaxSpeed * speedMod;
            JumpForce = JumpForce * jumpMod;
        }


        private void FixedUpdate()
        {
            Grounded = false;

            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            // This can be done using layers instead but Sample Assets will not overwrite your project settings.
            Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, GroundedRadius, WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                    Grounded = true;
            }
            Anim.SetBool("Ground", Grounded);

            // Set the vertical animation
            Anim.SetFloat("vSpeed", rb.velocity.y);
        }


        public void Move(float move, bool crouch, bool jump)
        {
            // If crouching, check to see if the character can stand up
            if (!crouch && Anim.GetBool("Crouch"))
            {
                // If the character has a ceiling preventing them from standing up, keep them crouching
                if (Physics2D.OverlapCircle(CeilingCheck.position, CeilingRadius, WhatIsGround))
                {
                    crouch = true;
                }
            }

            // Set whether or not the character is crouching in the animator
            Anim.SetBool("Crouch", crouch);

            //only control the player if grounded or airControl is turned on
            if (Grounded || AirControl)
            {
                // Reduce the speed if crouching by the crouchSpeed multiplier
                move = (crouch ? move*CrouchSpeed : move);

                // The Speed animator parameter is set to the absolute value of the horizontal input.
                Anim.SetFloat("Speed", Mathf.Abs(move));

                // Move the character
                rb.velocity = new Vector2(move*MaxSpeed, rb.velocity.y);

                // If the input is moving the player right and the player is facing left...
                if (move > 0 && !FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
                    // Otherwise if the input is moving the player left and the player is facing right...
                else if (move < 0 && FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
            }
            // If the player should jump...
            if (Grounded && jump && Anim.GetBool("Ground"))
            {
                // Add a vertical force to the player.
                Grounded = false;
                Anim.SetBool("Ground", false);
                rb.AddForce(new Vector2(0f, JumpForce));
            }
        }


        private void Flip()
        {
            // Switch the way the player is labelled as facing.
            FacingRight = !FacingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
