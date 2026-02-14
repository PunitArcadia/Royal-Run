using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    private Rigidbody rb;
    private GameManager gameManager;

    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private Vector2 clamp;

    private Vector2 move;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = FindFirstObjectByType<GameManager>();
    }

    private void FixedUpdate()
    {
        if (gameManager != null && !gameManager.IsGameActive) return;

        HandleMovement();
    }

    public void Move(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    private void HandleMovement()
    {
        Vector3 currentPosition = rb.position;
        Vector3 moveDirection = new Vector3(move.x, 0f, move.y);

        Vector3 newPosition = currentPosition +
                              moveDirection * (moveSpeed * Time.fixedDeltaTime);

        newPosition.x = Mathf.Clamp(newPosition.x, -clamp.x, clamp.x);
        newPosition.z = Mathf.Clamp(newPosition.z, -clamp.y, clamp.y);

        rb.MovePosition(newPosition);
    }
}
