using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceController : MonoBehaviour
{
    public bool inside = false;
    public List<GameObject> WallList;
    public bool hitCentre = false;

    // Start is called before the first frame update
    void Start(){
        GameObject Parent = transform.parent.gameObject;

        foreach (Transform child in Parent.transform){
            if (child.tag == "wall_disappear"){
                WallList.Add(child.gameObject);
            }
        }

        if (inside == true){
            Enter();
        }
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void Enter(){

        print("in Enter()");

        //make walls disappear
        foreach (GameObject child in WallList){
            child.GetComponent<Renderer>().enabled = false;
        }

    }

    public void Exit(){
        //disappear[0].GetComponent<Renderer>().enabled = true;
        //disappear[1].GetComponent<Renderer>().enabled = true;

        // make walls reappear
        foreach (GameObject child in WallList)
        {
            child.GetComponent<Renderer>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        // when player hits middle collider
        hitCentre = true;
        print("centre is hit");
    }

}
