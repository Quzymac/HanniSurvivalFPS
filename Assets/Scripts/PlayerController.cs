using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{

    [SerializeField] float speed = 5f;
    [SerializeField] float mouseSensitivity = 3f;

    [SerializeField] float gravity = 10f;
    [SerializeField] float jumpForce = 2f;
    Vector3 jump;
    bool jumpUsed = false;



    [Header("JetPack")]
    [SerializeField] float thrusterForce = 1000f;
    [SerializeField] float thrusterFuelBurnSpeed = 1f;
    [SerializeField] float thrusterFuelRegenSpeed = 0.3f;
    float thrusterFuelAmount = 1f;

    PlayerMotor motor;

    Rigidbody rb;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        if (Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

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

        //jump
        float disstanceToTheGround = GetComponent<Collider>().bounds.extents.y;

        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, disstanceToTheGround + 0.1f);
        if (isGrounded)
        {
            jumpUsed = false;

            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }

        }
        //thruster can only be used after releasing jump
        if (!isGrounded)
        {
            if (Input.GetButtonUp("Jump"))
            {
                jumpUsed = true;
            }
        }

        // Calculate the thrusterforce based on player input
        Vector3 _thrusterForce = Vector3.zero;
        if (Input.GetButton("Jump") && jumpUsed && !isGrounded && thrusterFuelAmount > 0f)
        {
            thrusterFuelAmount -= thrusterFuelBurnSpeed * Time.deltaTime;

            if (thrusterFuelAmount >= 0.01f)
            {
                _thrusterForce = Vector3.up * thrusterForce;
            }
        }
        else
        {
            thrusterFuelAmount += thrusterFuelRegenSpeed * Time.deltaTime;
        }

        thrusterFuelAmount = Mathf.Clamp(thrusterFuelAmount, 0f, 1f);

        // Apply the thruster force
        motor.ApplyThruster(_thrusterForce);
    }

    public float GetThrusterFuelAmount()
    {
        return thrusterFuelAmount;
    }
}
