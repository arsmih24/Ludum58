using UnityEngine;

namespace PlayerSystem 
{
    public class PlayerMovement
    {
        private float _sprintLeft;   
        private bool _isSprinting;   

        public void Move(Vector2 dir, Rigidbody2D rb, SpriteRenderer sr, Animator anim,
                    float walkSpeed, float sprintSpeed, float sprintDuration, float sprintRecharge, bool sprintHeld, bool canMove)
        {
            bool moving;
            if (canMove)
                moving = dir != Vector2.zero;
            else moving = false;

            anim.SetBool("IsMoving", moving);

            if (moving)
            {
                if ((Mathf.Abs(dir.y) > Mathf.Abs(dir.x)) || (Mathf.Abs(dir.y) == Mathf.Abs(dir.x)))
                {
                    if (dir.y > 0)
                    {
                        anim.SetTrigger("MoveUp");
                        anim.ResetTrigger("MoveDown");
                        anim.ResetTrigger("MoveSide");
                    }

                    else anim.SetTrigger("MoveDown");
                }
                else
                {
                    anim.SetTrigger("MoveSide");
                    sr.flipX = dir.x < 0;
                }
            }
            else 
            {
                anim.ResetTrigger("MoveUp");
                anim.ResetTrigger("MoveDown");
                anim.ResetTrigger("MoveSide");
            }

            if (moving && sprintHeld && _sprintLeft > 0f)
            {
                _isSprinting = true;
            }
            else if (!sprintHeld || !moving)
            {
                _isSprinting = false;
            }

            if (_isSprinting)
                _sprintLeft = Mathf.Max(0f, _sprintLeft - Time.deltaTime);
            else
                _sprintLeft = Mathf.Min(sprintDuration, _sprintLeft + Time.deltaTime * sprintRecharge);

            float speed = (_isSprinting && _sprintLeft > 0f) ? sprintSpeed : walkSpeed;
            rb.linearVelocity = dir.normalized * speed;
        }
    }
}

