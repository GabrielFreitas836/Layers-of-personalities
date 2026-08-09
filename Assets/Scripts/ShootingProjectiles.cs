using System.Collections;
using UnityEngine;

public class ShootingProjectiles : MonoBehaviour
{
    private EnemyPatrolling patrol;

    public GameObject projectile;

    public GameObject firePoint;

    [HideInInspector]
    public float direction;
    private bool canShoot = true;

    void Awake()
    {
        patrol = GetComponent<EnemyPatrolling>();
    }

    void Update()
    {
        var agent = patrol.agent;

        bool facingLeft = patrol.enemy.renderer.flipX;
        direction = facingLeft ? -1f : 1f;

        Vector3 firePointLocalPosition = firePoint.transform.localPosition;

        firePointLocalPosition.x = Mathf.Abs(firePointLocalPosition.x) * direction;

        firePoint.transform.localPosition = firePointLocalPosition;

        if (agent.isStopped)
        {
            if (canShoot)
            {
                canShoot = false;
                StartCoroutine(Shoot());
            }
        }
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(2.5f);
        Instantiate(projectile, firePoint.transform.position, firePoint.transform.rotation);
        canShoot = true;
    }
}
