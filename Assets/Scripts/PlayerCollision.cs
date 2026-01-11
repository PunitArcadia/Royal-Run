using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] Animator animator;
    GameManager gm;
    private void Start()
    {
       gm = FindFirstObjectByType<GameManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            gm.ChangeCoin(10);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Fence"))
        {
            animator.SetTrigger("hit");
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gm.ChangeLife(-1);
            Destroy(collision.gameObject);
        }
    }
}
