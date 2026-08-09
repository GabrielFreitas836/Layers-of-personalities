using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyData : ScriptableObject
{
    public Sprite enemySprite;
    public float enemySpeed;
    public int enemyHealth;
    public int enemyDamage;
    public float rangeAttack;

    public enum PowerType
    {
        darkAura,
        fireAura,
        iceAura
    }

    public PowerType enemyPower;
}
