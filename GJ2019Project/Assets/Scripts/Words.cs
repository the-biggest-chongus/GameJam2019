using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Words : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * 0.5f, ForceMode.Impulse);
    }
}
