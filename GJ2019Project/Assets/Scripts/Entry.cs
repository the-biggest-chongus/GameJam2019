using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entry : MonoBehaviour
{

    public EntranceController Controller;

    // Start is called before the first frame update
    void Start()
    {
        Controller = transform.parent.GetComponent<EntranceController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider coll){
        //check if centre is hit
        //if so, then call Controller.Enter
        if (coll.gameObject.tag == "Player"){
            if (Controller.hitCentre == true){
                Controller.hitCentre = false;
                Controller.Enter();
                print("called Controller.Enter");
            }
        }

    }
}
