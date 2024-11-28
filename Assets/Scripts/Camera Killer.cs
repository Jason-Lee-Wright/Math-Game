using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraKiller : MonoBehaviour
{
    public GameObject Player;
    public Vector3 Spawn;
    public GameObject Camera;

    [Range(0.0f, 1.0f)]
    public float interpoint = 0.0f;
    public float camrange;
    public float distance;
    Vector3 lastPostion;

    float LastTimeStartUp;
    float editorDeltaTime;


    private void Start()
    {
        Spawn = Player.transform.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * camrange);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(Camera.transform.position, Player.transform.position);
    }

    private void Update()
    {
        float dotProduct = Vector3.Dot(transform.forward, (Player.transform.position - transform.position).normalized);

        distance = Vector3.Distance(Camera.transform.position, Player.transform.position);

        if (dotProduct >= 0.975f && distance <= camrange)
        {
            Debug.Log(dotProduct + "I see you");

            Player.transform.position = Spawn;
        }
    }
}
