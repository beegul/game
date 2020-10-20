using System.ComponentModel;
using UnityEngine;

namespace Assets.Scripts.Movement
{
   public class PlayerMovement : MonoBehaviour
    {
        private float walkForwardsSpeed = 2.0f;
        private float walkBackwardsSpeed = 1.0f;
        private float walkCrouchedSpeed = 1.0f;
        private float runSpeed = 4.0f;
        private float jumpSpeed = 8.0f;
        private float dashSpeed = 0.5f;
        private float gravity = 20.0f;
        private float movementSpeed;

        private Vector3 moveDirection = Vector3.zero;

        private Animator animator;
        private CharacterController characterController;

        void Start()
        {
            characterController = GetComponent<CharacterController>();
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            if (characterController.isGrounded)
            {
                moveDirection = transform.TransformDirection(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
                moveDirection *= movementSpeed;
            }

            if (Input.GetKey(KeyCode.Space) && animator.GetBool("Run Forwards") ||
                Input.GetKeyDown(KeyCode.LeftShift) && animator.GetBool("Run Forwards"))
            {
                gravity = 0;
            }
            else
            {
                gravity = 20;
            }

            if (Input.GetKey(KeyCode.LeftShift) && animator.GetBool("Walking Forwards"))
            {
                movementSpeed = runSpeed;
            }
            else if (animator.GetBool("Walking Backwards"))
            {
                movementSpeed = walkBackwardsSpeed;
            }
            else if (animator.GetBool("Crouched Walking"))
            {
                movementSpeed = walkCrouchedSpeed;
            }
            else
            {
                movementSpeed = walkForwardsSpeed;
            }

            moveDirection.y -= gravity * Time.deltaTime;
            characterController.Move(moveDirection * Time.deltaTime);
        }
    }
}