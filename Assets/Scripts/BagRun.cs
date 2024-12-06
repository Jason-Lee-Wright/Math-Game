using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BagRun : MonoBehaviour
{
    public GameObject player;

    public GameObject pos1;
    public GameObject pos2;
    public GameObject pos3;
    public GameObject pos4;
    public GameObject pos5;

    public int speed = 10;
    public float distance = 5;

    private int run = 0;

    private bool moving = false;

    private Vector3 nextPosition;
    private Vector3 moveDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= distance && !moving)
        {
           moving = true;
        }

        if (moving)
        {
            Run();
        }
    }

    void Run()
    {
        run++;

        if ( run <= 3)
        {
            nextPosition = transform.position + new Vector3(0, 0, 5);

            moveDistance = transform.position - nextPosition;

            Vector3.MoveTowards(transform.position, nextPosition, speed);
        }
    }
}
