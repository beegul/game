using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;

    public float mouseSpeed = 3.0f;
    public float movementSpeed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float dashSpeed = 0.5f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;

    public Animator animator;

    private bool groundedPlayer;

    void Start(){
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed;

        transform.Rotate(0, mouseX, 0);

        if (!(Camera.main.transform.eulerAngles.x + (-mouseY) > 50 && Camera.main.transform.eulerAngles.x + (-mouseY) < 340)) {
            Camera.main.transform.RotateAround(transform.position, Camera.main.transform.right, -mouseY);
        }

        if (characterController.isGrounded)
        {
            moveDirection = transform.TransformDirection(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= movementSpeed;
        }

        if (Input.GetKey(KeyCode.Space) && animator.GetBool("Run Forwards") ||
            Input.GetKey(KeyCode.Space) && animator.GetBool("Run Backwards") ||
            Input.GetKeyDown(KeyCode.LeftShift) && animator.GetBool("Run Forwards")) {
            gravity = 0;
        }
        else {
            gravity = 20;
        }

        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);     
    }
}