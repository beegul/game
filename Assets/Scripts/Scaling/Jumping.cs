using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Scaling
{
    public class Jumping : MonoBehaviour
    {
        private static CharacterController characterController;
        private static Animator animator;

        //Set the private variables to enable correct crouch scaling.
        public static void Initialize(CharacterController characterController, Animator animator)
        {
            Jumping.characterController = characterController;
            Jumping.animator = animator;
        }


        public static void JumpLogic() {

            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Jump Forwards")){

               characterController.height = animator.GetFloat("JumpForwardsColliderHeight");

               Ray ray = new Ray(characterController.transform.position + Vector3.up, -Vector3.up);
               RaycastHit hitInfo = new RaycastHit();

               if (Physics.Raycast(ray, out hitInfo))
               {

                   if (hitInfo.distance > 0.3f)
                   {
                       animator.MatchTarget(hitInfo.point, Quaternion.identity, AvatarTarget.Root,
                           new MatchTargetWeightMask(new Vector3(0, 1, 0), 0), 0.35f, 0.5f);
                   }
               }
           }
        }
    }
}