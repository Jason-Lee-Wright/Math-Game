using System.Collections;
using UnityEngine;

public class Bulletbounce : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float speed;

    private BagRun BagRun;

    private void Start()
    {
        BagRun = GetComponent<BagRun>();
    }

    void Update()
    {
        if (BagRun.win == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SpawnBullet();
            }
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
