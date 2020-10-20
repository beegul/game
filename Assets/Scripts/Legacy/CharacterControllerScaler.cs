using UnityEngine;

public class CharacterControllerScaler : MonoBehaviour
{
    public Animator animator;
    CharacterController characterController;

    float defaultHeight;
    Vector3 defaultCenter;

    private float crouchHeight = 1.35f;
    private float crouchCenter = 0.7f;

    void Start()
    {
        animator = GetComponent<Animator>();

        characterController = GetComponent<CharacterController>();

        defaultHeight = characterController.height;
        defaultCenter = characterController.center;
    }

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Crouching Idle") 
            || animator.GetCurrentAnimatorStateInfo(0).IsName("Crouched Walking")
            || animator.GetCurrentAnimatorStateInfo(0).IsName("Crouched Walking Backwards"))
        {            
            characterController.height = crouchHeight;
            characterController.center = new Vector3(0, crouchCenter, 0);
        }
        else
        {
            characterController.height = defaultHeight;
            characterController.center = defaultCenter;
        }



        /*if (animator.GetCurrentAnimatorStateInfo(0).IsName("Jump Forwards"))
        {
            characterController.height = animator.GetFloat("JumpForwardsColliderHeight");

            Ray ray = new Ray(transform.position + Vector3.up, -Vector3.up);
            RaycastHit hitInfo = new RaycastHit();

            if (Physics.Raycast(ray, out hitInfo))
            {

                if (hitInfo.distance > 0.3f)
                {
                    animator.MatchTarget(hitInfo.point, Quaternion.identity, AvatarTarget.Root,
                        new MatchTargetWeightMask(new Vector3(0, 1, 0), 0), 0.35f, 0.5f);
                }
            }
        }*/

        /*if (animator.GetCurrentAnimatorStateInfo(0).IsName("Forward Roll"))
        {
            characterController.height = animator.GetFloat("ForwardRollColliderHeight");
            characterController.center = new Vector3(0, 0.5f, 0);
        }
        else {
            characterController.center = new Vector3(0, 0.9f, 0);
        }*/



    }
}

