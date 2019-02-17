using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Words : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<Rigidbody>().AddForce(transform.forward * 0.5f, ForceMode.Impulse);
        transform.Translate(Vector3.forward * Time.deltaTime * 15);
        GetComponent<Rigidbody>().AddForce(-transform.up * 2f, ForceMode.Impulse);
    }
}
