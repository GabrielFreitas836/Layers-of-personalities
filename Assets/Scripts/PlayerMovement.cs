using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalInput;

    private Rigidbody2D rb;

    private GameManager gameManager;
    private Animator animator;

    // Usando hash melhora a performance de executar a transição entre as animações
    private int movingHash = Animator.StringToHash("isMoving");

    private SpriteRenderer playerSprite;

    private BoxCollider2D boxCollider;

    private float originalBoxOffset;

    public float horizontalSpeed = 4f;
    public float jumpForce = 5f;

    public Transform groundCheck;
    public LayerMask groundLayer;

    private bool isOnGround;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        playerSprite = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        originalBoxOffset = Mathf.Abs(boxCollider.offset.x);
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        isOnGround = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        animator.SetBool(movingHash, horizontalInput != 0);

        Vector2 currentBoxOffset = boxCollider.offset;
        // Mudar direção do player dependendo se ele estiver indo pra esquerda ou direita
        if (horizontalInput > 0f)
        {
            playerSprite.flipX = false;

            currentBoxOffset.x = originalBoxOffset;

            boxCollider.offset = currentBoxOffset;
        }
        else if (horizontalInput < 0f)
        {
            playerSprite.flipX = true;
            currentBoxOffset.x = -originalBoxOffset;

            boxCollider.offset = currentBoxOffset;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new(horizontalInput * horizontalSpeed, rb.velocity.y);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingObject") && horizontalInput == 0)
        {
            rb.AddForce(new(gameManager.speed * 200f, 0f));
        }
    }
}
