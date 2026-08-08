using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalInput;

    private Rigidbody2D rb;

    private Animator animator;

    // Usando hash melhora a performance de executar a transição entre as animações
    private int movingHash = Animator.StringToHash("isMoving");

    public float horizontalSpeed = 4f;
    public float jumpForce = 5f;

    public Transform groundCheck;
    public LayerMask groundLayer;

    private bool isOnGround;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        isOnGround = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        animator.SetBool(movingHash, horizontalInput != 0);
    }

    void FixedUpdate()
    {
        rb.velocity = new(horizontalInput * horizontalSpeed, rb.velocity.y);
    }
}
