using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private float speed = 9f;
    [SerializeField] private float jumpForce = 6f;
    [SerializeField] private LayerMask jumplayermask;
    [SerializeField] private float downForce;
    [SerializeField] private float mouseSensitivity = 100f;
    private float camRotation;
    private float _speed;

    [Header("Components")]
    [SerializeField] private Camera Camera;
    [SerializeField] private Rigidbody Rigidbody;

    private void Update()
    {



        //WASD
        Vector3 keyboardInput = GetInput("Keyboard");
        Rigidbody.velocity = new Vector3(speed * keyboardInput.x, Rigidbody.velocity.y, speed * keyboardInput.z);

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Rigidbody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
        if (Rigidbody.velocity.y < 0 && Rigidbody.velocity.y > -4f && IsGrounded() == false) Rigidbody.AddForce(Vector3.down * downForce,ForceMode.Acceleration);

        //Mouse
        Vector2 mouseInput = GetInput("Mouse");
        transform.Rotate(Vector3.up * mouseInput.x);
        camRotation -= mouseInput.y; camRotation = Mathf.Clamp(camRotation, -85, 85);
        Camera.transform.localRotation = Quaternion.Euler(camRotation, 0, 0);
    }

    //checks to see if there is a colider below the player
    public bool IsGrounded()
    {
        bool isGrounded = true;
        if (Physics.Raycast(transform.position + new Vector3(0.4f, 1, 0), Vector3.down, 1.1f) ||
            Physics.Raycast(transform.position + new Vector3(-0.4f, 1, 0), Vector3.down, 1.1f) ||
            Physics.Raycast(transform.position + new Vector3(0, 1, 0.4f), Vector3.down, 1.1f) ||
            Physics.Raycast(transform.position + new Vector3(0, 1, -0.4f), Vector3.down, 1.1f))
        {
            isGrounded = true;
        }
        else
        { isGrounded = false; }

        return isGrounded;
    }

    //Get "Keyboard" or "Mouse" Input
    private Vector3 GetInput(string input)
    {
        Vector3 playerInput = new Vector3(0, 0, 0);
        _speed = speed;
        switch (input)
        {
            case "Keyboard":
                float keybH = Input.GetAxisRaw("Horizontal");
                float keybV = Input.GetAxisRaw("Vertical");
                playerInput = (keybH * transform.right + keybV * transform.forward).normalized;
                break;

            case "Mouse":
                float mousX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
                float mousY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
                playerInput = new Vector3(mousX, mousY, 0);
                break;

            default:
                Debug.LogError("The only valid strings for this methods are Mouse & Keyboard");
                break;
        }
        return playerInput;
    }

}
