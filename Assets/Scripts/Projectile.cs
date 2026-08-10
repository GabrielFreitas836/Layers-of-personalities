using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed = 20f;

    public Rigidbody2D rb;

    private GameObject[] enemies;
    private Enemy enemy;

    private EnemyPatrolling enemyPatrolling;
    private SpriteRenderer sprite;

    public Sprite[] projectileSprites;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void Start()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemy = enemies[i].GetComponent<Enemy>();
            foreach (Sprite projectileSprite in projectileSprites)
            {
                if (enemy.data.enemyPower == EnemyData.PowerType.darkAura &&
                    projectileSprite.name == "DefaultProjectile")
                {
                    sprite.sprite = projectileSprite;
                    break;
                }
                else if (enemy.data.enemyPower == EnemyData.PowerType.fireAura && 
                projectileSprite.name == "FireProjectile")
                {
                    sprite.sprite = projectileSprite;
                    break;
                }
                else if (enemy.data.enemyPower == EnemyData.PowerType.iceAura && 
                projectileSprite.name == "IceProjectile")
                {
                    sprite.sprite = projectileSprite;
                    break;
                }
            }
        }
        
        for (int i = 0; i < enemies.Length; i++)
        {
            enemyPatrolling = enemies[i].GetComponentInChildren<EnemyPatrolling>();

            if (Mathf.Abs(enemyPatrolling.playerTransform.position.x) - Mathf.Abs(enemyPatrolling.enemyTransform.position.x) >= -enemy.data.rangeAttack - 2.5f)
            {
                var shooter = enemies[i].GetComponentInChildren<ShootingProjectiles>();

                float direction = 1f;
                if (shooter != null)
                {
                    direction = shooter.direction;
                }

                rb.velocity = new Vector2(direction * speed, 0f);
                break;
            }
        }

        
    }
}
