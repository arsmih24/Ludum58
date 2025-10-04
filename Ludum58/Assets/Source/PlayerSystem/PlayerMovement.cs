using UnityEngine;

namespace PlayerSystem 
{
    public class PlayerMovement
    {
        private float _sprintLeft;   
        private bool _isSprinting;   
        private bool _wasMoving;

        public void Move(Vector2 dir, Rigidbody2D rb, SpriteRenderer sr, Animator anim,
                    float walkSpeed, float sprintSpeed, float sprintDuration, float sprintRecharge, bool sprintHeld)
        {
            bool moving = dir != Vector2.zero;

            //anim.SetBool("IsMoving", moving);
            if (moving)
            {
                sr.flipX = dir.x < 0;
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

            _wasMoving = moving;
        }
    }
}

