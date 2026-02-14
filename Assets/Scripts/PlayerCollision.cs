using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameManager != null && !gameManager.IsGameActive)
            return;

        if (collision.gameObject.CompareTag("Coin"))
        {
            HandleCoin(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Fence"))
        {
            HandleFence();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            HandleObstacle(collision.gameObject);
        }
    }

    private void HandleCoin(GameObject coin)
    {
        gameManager.ChangeCoin(10);
        Destroy(coin);
    }

    private void HandleFence()
    {
        if (animator != null)
        {
            animator.SetTrigger("hit");
        }
    }

    private void HandleObstacle(GameObject obstacle)
    {
        gameManager.ChangeLife(-1);
        Destroy(obstacle);
    }
}