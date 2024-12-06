using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BagRun : MonoBehaviour
{
    public GameObject player;
    public GameObject Canvas;

    public int speed = 10;
    public float distance = 5;
    public float runD = 5;

    private bool running = false;

    private bool moving = false;

    private Vector3 nextPosition;
    private Vector3 moveDistance;
    private Vector3 prevPosition;
    private Transform spawn;

    // Start is called before the first frame update
    public void Start()
    {
        Canvas.SetActive(false);
        Vector3 stop = new Vector3 (0, 0 , runD);
        spawn = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(spawn.transform.position.y - transform.position.y) < 0.1f)
        {
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        }

        if (Vector3.Distance(player.transform.position, transform.position) <= distance && !moving)
        {
            Debug.Log("player in range");
           moving = true;
        }

        if (moving)
        {
            Run();
        }

        if (running)
        {
            Vector3 nextPosition = transform.position + transform.forward * speed * Time.deltaTime;

            transform.position = nextPosition;
        }

        if (Vector3.Distance(prevPosition, transform.position) >= runD)
        {
            running = false;
        }
    }

    void Run()
    {
        Debug.Log("Run");

        transform.forward = (player.transform.position - transform.position) * -1;

        nextPosition = transform.position + new Vector3(0, 0, runD);

        Debug.Log(nextPosition);

        moveDistance = transform.position + nextPosition;

        running = true;
        moving = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Canvas.SetActive(true);
        }
    }
}
