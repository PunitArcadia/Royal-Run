using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float moveSpeed = 10;
    [SerializeField] Vector2 clamp;
    Vector2 move;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        HandleMovement();
    }
    public void Move(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
        Debug.Log(move);
    }

    public void HandleMovement()
    {
        Vector3 currentPosition = rb.position;
        Vector3 moveDirection = new Vector3(move.x, 0f, move.y);
        Vector3 newPosition = currentPosition + moveDirection * (moveSpeed * Time.fixedDeltaTime);
        newPosition.x = Mathf.Clamp(newPosition.x, -clamp.x, clamp.x);
        newPosition.z = Mathf.Clamp(newPosition.z, -clamp.y, clamp.y);
        rb.MovePosition(newPosition);
    }
}
