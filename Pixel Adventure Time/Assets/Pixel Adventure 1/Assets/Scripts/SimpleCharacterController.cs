using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SimpleCharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Transform thisTransform;
    private Vector3 velocity;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        thisTransform = transform;
    }

    private void Update()
    {
        MoveAndJump();
        KeepCharacterOnXAxis();
    }

    private void MoveAndJump()
    {
        // Get horizontal input
        float moveInput = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(moveInput, 0f, 0f) * moveSpeed;

        if (controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("Jump triggered!");
                velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            }
            else
            {
                // slight downward force to keep contact with ground
                velocity.y = -2f;
            }
        }
        else
        {
            // apply gravity while in air
            velocity.y += gravity * Time.deltaTime;
        }

        // combine vertical and horizontal movement
        move.y = velocity.y;

        controller.Move(move * Time.deltaTime);
    }

    private void KeepCharacterOnXAxis()
    {
        var currentPosition = thisTransform.position;
        currentPosition.z = 0f;
        thisTransform.position = currentPosition;
    }
}

