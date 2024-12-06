using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Bulletbounce : MonoBehaviour
{
    public GameObject Bullet;
    public Transform bulletSpawn;
    public Vector3 startPoint;
    public int bounce;
    public float speed;

    private CameraKiller killer;
    private Rigidbody rb;

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
        GameObject newBullet = Instantiate(Bullet, bulletSpawn.position, bulletSpawn.rotation);
        Rigidbody newRb = newBullet.GetComponent<Rigidbody>();

        if (newRb != null)
        {
            newRb.velocity = bulletSpawn.forward * speed;
        }

        bounce = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit an object");

        if (collision.gameObject.CompareTag("Camera"))
        {
            Debug.Log("it was the cam");
            Destroy(collision.gameObject);
        }
        else
        {
            Debug.Log("it was not the cam");
            if (bounce <1)
            {
                bounce++;

                Debug.Log("add bouce");

                Vector3 initalVelocity = rb.velocity;
                Vector3 normal = collision.contacts[0].normal;
                Vector3 reflectedVelocity = Vector3.Reflect(initalVelocity, normal);

                rb.velocity = reflectedVelocity;
            }
            else if (bounce >= 1)
            {
                Debug.Log("kill bullet");
                Destroy(Bullet);
            }
        }
    }
}
