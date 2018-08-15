using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    [SerializeField] float speed = 5f;
    [SerializeField] float mouseSensitivity = 3f;

    PlayerMotor motor;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        //calculate movement velocity as a 3D vector
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMov;
        Vector3 moveVertical = transform.forward * zMov;

        //Always the same speed, even when moving in multiple directions
        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        //apply movement
        motor.Move(velocity);

        //calculate rotation as 3d vector (turning around)
        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0f, yRot, 0f) * mouseSensitivity;

        //apply rotation
        motor.Rotate(rotation);

        //calculate camera rotation (up and down)
        float xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 cameraRotation = new Vector3(xRot, 0f, 0f) * mouseSensitivity;

        //apply camera rotation
        motor.RotateCamera(cameraRotation);

    }

}
