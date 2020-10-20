using UnityEngine;

namespace Assets.Scripts.Scaling
{
    public class Scaler : MonoBehaviour
    {
        private Animator animator;
        private CharacterController characterController;

        // Use this for initialization
        void Start()
        {
            animator = GetComponent<Animator>();
            characterController = GetComponent<CharacterController>();

            //Initialize the crouch class with default values.
            Crouching.Initialize(characterController.height, characterController.center, characterController, animator);
        }

        // Update is called once per frame
        void Update()
        {
            Crouching.CrouchLogic();
            Jumping.JumpLogic();
        }
    }
}