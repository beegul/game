using UnityEngine;

namespace Assets.Scripts.Camera
{
    public class CameraController : MonoBehaviour
    {
        private float mouseSpeed = 3.0f;

        void Start()
        {
            Cursor.visible = false;
        }

        void Update()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed;

            transform.Rotate(0, mouseX, 0);

            if (!(UnityEngine.Camera.main.transform.eulerAngles.x + (-mouseY) > 50 && UnityEngine.Camera.main.transform.eulerAngles.x + (-mouseY) < 340)) {
                UnityEngine.Camera.main.transform.RotateAround(transform.position, UnityEngine.Camera.main.transform.right, -mouseY);
            }
        }
    }
}