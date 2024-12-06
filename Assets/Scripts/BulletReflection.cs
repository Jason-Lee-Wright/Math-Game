using UnityEngine;

public class BulletReflection : MonoBehaviour
{
    public int maxBounces = 100;
    private int currentBounces = 0;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody found on bullet!");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Camera"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        else if (currentBounces < maxBounces)
        {
            Vector3 normal = collision.contacts[0].normal;
            Vector3 reflectedVelocity = Vector3.Reflect(rb.velocity.normalized, normal) * rb.velocity.magnitude;

            rb.velocity = reflectedVelocity;
            currentBounces++;
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
