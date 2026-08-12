using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public Rigidbody2D projRb;
    public float speed = 20f;

    private int direction = 1;

    private GameManager gameManager;

    void Awake()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }
    void Start()
    {
        projRb.velocity = new(direction * speed, 0f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemySprite"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.name == "DefaultTileMap")
        {
            Destroy(gameObject);
        }
    }
}
