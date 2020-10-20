using System.Runtime.CompilerServices;
using UnityEngine;

namespace Assets.Scripts.Scaling
{
    public class Crouching : MonoBehaviour
    {
        private static float crouchHeight = 1.35f;
        private static float crouchCenter = 0.7f;

        private static float defaultHeight;
        private static Vector3 defaultCenter;

        private static CharacterController characterController;
        private static Animator animator;

        //Set the private variables to enable correct crouch scaling.
        public static void Initialize(float height, Vector3 center, CharacterController characterController, Animator animator) {
           
            defaultHeight = height;
            defaultCenter = center;
            Crouching.characterController = characterController;
            Crouching.animator = animator;
        }

        //Execute the different crouch logic based on the current animation.
        public static void CrouchLogic()
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Crouched")
                 || animator.GetCurrentAnimatorStateInfo(0).IsName("Crouched Walking Forwards")
                 || animator.GetCurrentAnimatorStateInfo(0).IsName("Crouched Walking Backwards"))
            {
                CrouchedScale();
            }
            else
            {
                DefaultScale();
            }
        }

        //Scale the character controller when crouched.
        public static void CrouchedScale(){

            characterController.height = crouchHeight;
            characterController.center = new Vector3( 0, crouchCenter, 0);
        }

        //Set the characters height and center back to default values.
        public static void DefaultScale() {

            characterController.height = defaultHeight;
            characterController.center = defaultCenter;
        }   
    }
}