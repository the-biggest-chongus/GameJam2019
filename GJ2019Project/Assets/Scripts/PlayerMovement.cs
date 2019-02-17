using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 forward, right;
    float speed = 6f;
    public GameObject projectile;

    float lastJumpTime = 0;
    float jumpRate = 0.1f;

    
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
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
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
            //transform.forward = Vector3.Normalize(forwardDirection + rightDirection);
            transform.position += rightDirection;
            transform.position += forwardDirection;

            //movement "animation"
            if (Physics.Raycast(transform.position, Vector3.down, 0.0000001f))
            {
                if (lastJumpTime + jumpRate < Time.time)
                {
                    GetComponent<Rigidbody>().AddForce(Vector3.up * 2, ForceMode.Impulse);
                    lastJumpTime = Time.time;
                }                
            }
            

        }

        //shoot position based on mouse position, looks for a "Terrain" tag
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;
        Vector3 targetPos;
        if (Physics.Raycast(ray, out Hit, 100))
        {
            if (Hit.collider.gameObject.tag == "Terrain")
            {
                Debug.DrawRay(transform.position, transform.position, Color.red);
            }
        }
        targetPos = Hit.point;
        targetPos.y = transform.position.y;
        transform.LookAt(targetPos);



        //Shooting
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0) )
        {

            GameObject bulletShot = Instantiate(projectile, transform.position + new Vector3(0,0.1f,0)+transform.forward, Quaternion.identity);
            bulletShot.transform.forward = transform.forward;
        }
    }

}
