using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject firePoint;

    public GameObject projectilePrefab;

    private bool canShoot = true;

    void Update()
    {
        bool facingLeft = gameObject.GetComponent<SpriteRenderer>().flipX;
        float direction = facingLeft ? -1f : 1f;

        Vector3 firePointLocalPosition = firePoint.transform.localPosition;

        firePointLocalPosition.x = Mathf.Abs(firePointLocalPosition.x) * direction;

        firePoint.transform.localPosition = firePointLocalPosition;

        if (Input.GetKey(KeyCode.F) && canShoot)
        {
            canShoot = false;
            StartCoroutine(Shoot(firePoint.transform.position));
        }
    }

    IEnumerator Shoot(Vector2 localPosition)
    {
        yield return new WaitForSeconds(0.2f);
        Instantiate(projectilePrefab, localPosition, firePoint.transform.rotation);
        canShoot = true;
    }
}
