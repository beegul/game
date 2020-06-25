using UnityEngine;

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


        if (Input.GetKey(KeyCode.W)){
            animator.SetBool("Run Forwards", true);
        }
        else{
            animator.SetBool("Run Forwards", false);
        }

        if (Input.GetKey(KeyCode.S)){
            animator.SetBool("Run Backwards", true);
        }
        else{
            animator.SetBool("Run Backwards", false);
        }

        if (Input.GetKey(KeyCode.Space) && animator.GetBool("Run Forwards"))
        {
            animator.SetBool("Jump Forwards", true);
        }
        else{
            animator.SetBool("Jump Forwards", false);
        }

        if (Input.GetKey(KeyCode.Space) && animator.GetBool("Run Backwards")){
            animator.SetBool("Jump Backwards", true);
        }
        else{
            animator.SetBool("Jump Backwards", false);
        }

        if (Input.GetKey(KeyCode.Space) && !animator.GetBool("Run Forwards"))
        {
            animator.SetBool("Jump Idle", true);
        }
        else
        {
            animator.SetBool("Jump Idle", false);
        }

         if (Input.GetKey(KeyCode.A)){
             animator.SetBool("Strafe Left", true);
         }
         else{
             animator.SetBool("Strafe Left", false);
         }

         if (Input.GetKey(KeyCode.D)){
             animator.SetBool("Strafe Right", true);
         }
         else{
             animator.SetBool("Strafe Right", false);
         }

        if (Input.GetKeyDown(KeyCode.LeftShift) && animator.GetBool("Run Forwards")){
            animator.SetBool("Forward Roll", true);
        }
        else {
            animator.SetBool("Forward Roll", false);
        }



        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (!crouch) {
                animator.SetBool("Crouching Idle", true);
                crouch = true;
            }
            else
            {
                animator.SetBool("Crouching Idle", false);
                crouch = false;
            }
        }
    }
}
