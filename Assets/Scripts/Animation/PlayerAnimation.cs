using UnityEngine;



namespace Assets.Scripts.Animation
{
    public class PlayerAnimation : MonoBehaviour
    {
        public Animator animator;
        CharacterController characterController;

        private bool crouch;

        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
            characterController = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {


            if (Input.GetKey(KeyCode.W) && !crouch)
            {
                animator.SetBool("Walking Forwards", true);
            }
            else
            {
                animator.SetBool("Walking Forwards", false);
            }

            if (Input.GetKey(KeyCode.S))
            {
                animator.SetBool("Walking Backwards", true);
            }
            else
            {
                animator.SetBool("Walking Backwards", false);
            }

            if (Input.GetKey(KeyCode.Space) && animator.GetBool("Walking Forwards")
                || (Input.GetKey(KeyCode.Space) && animator.GetBool("Run Forwards")))
            {
                animator.SetBool("Jump Forwards", true);
            }
            else
            {
                animator.SetBool("Jump Forwards", false);
            }

            if (Input.GetKey(KeyCode.Space) && !animator.GetBool("Walking Forwards"))
            {
                animator.SetBool("Jump Idle", true);
            }
            else
            {
                animator.SetBool("Jump Idle", false);
            }

            if (Input.GetKey(KeyCode.A))
            {
                animator.SetBool("Strafe Left", true);
            }
            else
            {
                animator.SetBool("Strafe Left", false);
            }

            if (Input.GetKey(KeyCode.D))
            {
                animator.SetBool("Strafe Right", true);
            }
            else
            {
                animator.SetBool("Strafe Right", false);
            }

            if (Input.GetKey(KeyCode.LeftShift) && animator.GetBool("Walking Forwards"))
            {

                animator.SetBool("Run Forwards", true);
            }
            else
            {
                animator.SetBool("Run Forwards", false);
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                if (!crouch)
                {
                    animator.SetBool("Crouched", true);
                    crouch = true;
                }

                else
                {
                    animator.SetBool("Crouched", false);
                    crouch = false;
                }
            }

            if (Input.GetKey(KeyCode.W) && animator.GetBool("Crouched"))
            {
                animator.SetBool("Crouched Walking Forwards", true);

            }
            else
            {
                animator.SetBool("Crouched Walking Forwards", false);
            }

            if (Input.GetKey(KeyCode.W) && crouch == false)
            {
                animator.SetBool("Walking Forwards", true);
            }
            else if (Input.GetKey(KeyCode.W) && crouch == false)
            {
                animator.SetBool("Crouched Walking Forwards", true);
            }


            if (Input.GetKey(KeyCode.S) && animator.GetBool("Crouching Idle"))
            {
                animator.SetBool("Crouched Walking Backwards", true);

            }
            else
            {
                animator.SetBool("Crouched Walking Backwards", false);
            }

            if (Input.GetKey(KeyCode.S) && crouch == false)
            {
                animator.SetBool("Walking Backwards", true);
            }
            else if (Input.GetKey(KeyCode.S) && crouch == true)
            {
                animator.SetBool("Crouched Walking Backwards", true);
                animator.SetBool("Walking Backwards", false);
            }

        }
    }
}