using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionNPC : MonoBehaviour
{
    int happyState = 0;
    public GameObject heartParticles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            print("happy state");
            happyState = 1;
            GameObject particlePlaced = Instantiate(heartParticles, transform.position + new Vector3(0, 0.7f, 0), Quaternion.identity);
            particlePlaced.transform.parent = gameObject.transform;
            particlePlaced.transform.localScale = new Vector3(1, 1, 1);
        }

    }
}
