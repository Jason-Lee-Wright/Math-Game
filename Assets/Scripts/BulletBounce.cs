using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Bulletbounce : MonoBehaviour
{
    public GameObject Bullet;
    public Transform bulletSpawn;
    public int bounce;
    public float speed;

    private CameraKiller killer;
    private Rigidbody rb;
    private GameObject newBullet;
    private Rigidbody newRb;

    // Start is called before the first frame update
    void Start()
    {
        killer = GetComponent<CameraKiller>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnBullet();
        }
    }

    void SpawnBullet()
    {
        newBullet = Instantiate(Bullet, bulletSpawn.position, bulletSpawn.rotation);
        newRb = newBullet.GetComponent<Rigidbody>();

        if (newRb != null)
        {
            newRb.velocity = bulletSpawn.forward * speed;
        }

        bounce = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Camera"))
        {
            Destroy(collision.gameObject);
        }
        else
        {
            if (bounce <1)
            {
                bounce++;

                Vector3 initalVelocity = newRb.velocity;
                Vector3 normal = collision.contacts[0].normal;
                Vector3 reflectedVelocity = Vector3.Reflect(initalVelocity, normal);

                newRb.velocity = reflectedVelocity;
            }
            else if (bounce >= 1)
            {
                Destroy(newBullet);
            }
        }
    }
}
