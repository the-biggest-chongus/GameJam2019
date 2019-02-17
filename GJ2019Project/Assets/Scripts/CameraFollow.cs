using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject player;
    public float zoom = 50f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.position = Vector3.Slerp(transform.position,
                new Vector3(player.transform.position.x - zoom, player.transform.position.y + zoom, player.transform.position.z - zoom),
                2f * Time.deltaTime);
        }
    }
}
