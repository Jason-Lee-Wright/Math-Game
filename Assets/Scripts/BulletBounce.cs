using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletbounce : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject bulletSpawn;
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
            Bullet.transform.position = bulletSpawn.transform.position;

            Bullet.transform.position = Bullet.transform.position + transform.forward * speed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Camera"))
        {
            killer.Camera.SetActive(false);
        }
        else
        {
            if (bounce <1)
            {
                bounce++;

                Vector3 initalVelocity = rb.velocity;
                Vector3 normal = collision.contacts[0].normal;
                Vector3 reflectedVelocity = Vector3.Reflect(initalVelocity, normal);

                rb.velocity = reflectedVelocity;
            }
            else if (bounce >= 1)
            {
                Destroy(Bullet);
            }
        }
    }
}
