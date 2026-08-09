using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData data;

    public new SpriteRenderer renderer;

    void Start()
    {
        renderer.sprite = data.enemySprite;
    }

}
