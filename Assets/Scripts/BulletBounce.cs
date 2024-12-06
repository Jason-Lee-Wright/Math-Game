using System.Collections;
using UnityEngine;

public class Bulletbounce : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float speed;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnBullet();
        }
    }

    void SpawnBullet()
    {
        GameObject newBullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        Rigidbody bulletRb = newBullet.GetComponent<Rigidbody>();

        if (bulletRb != null)
        {
            bulletRb.velocity = bulletSpawn.forward * speed;
        }
    }
}
