using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private GameObject[] movObjs;

    public float distance = 2f;
    public float speed = 1f;

    private float t;

    public Text fpsText;
    private int fps;

    public int maxPlayerHealth = 100;

    private int currentHealth;

    public HealthBar healthBar;

    private Animator animator;

    private int dyingHash = Animator.StringToHash("isDying");

    public Rigidbody2D playerRb;

    private PlayerMovement playerMovement;

    void Awake()
    {
        movObjs = GameObject.FindGameObjectsWithTag("MovingObject");
        animator = GameObject.FindWithTag("Player").GetComponent<Animator>();
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

    void Start()
    {
        StartCoroutine(FPSText());

        currentHealth = maxPlayerHealth;
        healthBar.SetMaxHealth(maxPlayerHealth);
    }
    void Update()
    {
        // Resetar level atual ao apertar R
        if (Input.GetKey(KeyCode.R))
        {
            ResetLevel();
        }

        t += Time.deltaTime * speed;
        foreach (GameObject movObj in movObjs)
        {
            float x = Mathf.Lerp(distance -2f, distance + 0.75f, Mathf.PingPong(t, 1f));
            Vector2 pos = movObj.transform.position;
            pos.x = x;

            movObj.transform.position = pos;

        }

        if (currentHealth == 0)
        {
            playerMovement.dying = true;
            StartCoroutine(PlayerDying());
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    private void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    IEnumerator FPSText()
    {
        while (true)
        {
            fps = (int)(1f / Time.unscaledDeltaTime);
            fpsText.text = $"FPS: {fps}";
            yield return new WaitForSecondsRealtime(1.5f);
        }
    }

    IEnumerator PlayerDying()
    {
        animator.SetBool(dyingHash, true);
        playerRb.bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(1f);
        playerMovement.dying = false;
        playerRb.bodyType = RigidbodyType2D.Dynamic;
        ResetLevel();
    }
}
