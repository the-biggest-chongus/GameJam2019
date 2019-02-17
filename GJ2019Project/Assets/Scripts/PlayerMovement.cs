using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 forward, right;
    public float speed = 12f;
    // Start is called before the first frame update
    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    // Update is called once per frame
    void Update()
    {
        //wasd movement
        if (Input.anyKey)
        {
            Vector3 forwardDirection = new Vector3(0,0,0);
            Vector3 rightDirection = new Vector3(0, 0, 0);
            if (Input.GetKey(KeyCode.W))
            {
                forwardDirection = forward * Time.deltaTime * speed;             
            }
            if (Input.GetKey(KeyCode.A))
            {
                rightDirection = -right * Time.deltaTime * speed;
            }
            if (Input.GetKey(KeyCode.S))
            {
                forwardDirection = -forward * Time.deltaTime * speed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                rightDirection = right * Time.deltaTime * speed;
            }
            transform.forward = Vector3.Normalize(forwardDirection + rightDirection);
            transform.position += rightDirection;
            transform.position += forwardDirection;

        }
    }
}
