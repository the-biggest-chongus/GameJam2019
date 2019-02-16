using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceCollider : MonoBehaviour
{
    public string status = "outside";
    public GameObject parent;
    public GameObject[] disappear = new GameObject[2];

    // Start is called before the first frame update
    void Start(){

    }

    // Update is called once per frame
    void Update() {
        
    }

    public void Enter(){
        disappear[0].GetComponent<Renderer>().enabled = false;
        disappear[1].GetComponent<Renderer>().enabled = false;
    }

    public void Exit(){
        disappear[0].GetComponent<Renderer>().enabled = true;
        disappear[1].GetComponent<Renderer>().enabled = true;
    }



}
