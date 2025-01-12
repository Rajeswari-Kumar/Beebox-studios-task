using UnityEngine;

public class FPC : MonoBehaviour
{
    public float speed = 10f; 
    public float mouseSensitivity = 2f; 
    public Transform playerCamera;
    private float cameraRotationX = 0f;
    private float cameraRotationY = 0f;
    public GameObject player;
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");


        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        player.transform.Translate(move * speed * Time.deltaTime, Space.World);

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;

        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        player.transform.Rotate(Vector3.up * mouseX); 
        cameraRotationX -= mouseY;
        cameraRotationX = Mathf.Clamp(cameraRotationX, -90f, 90f);

        cameraRotationY += mouseX;
        cameraRotationY = Mathf.Clamp(cameraRotationY , -90f, 90f);
        playerCamera.localRotation = Quaternion.Euler(cameraRotationX, cameraRotationY, 0f);

    }
}
