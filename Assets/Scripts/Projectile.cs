using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed = 20f;

    public Rigidbody2D rb;

    void Start()
    {
        var shooter = FindObjectOfType<ShootingProjectiles>();

        float direction = 1f;
        if (shooter != null)
        {
            direction = shooter.direction;
        }

        rb.velocity = new Vector2(direction * speed, 0f);
    }
}
