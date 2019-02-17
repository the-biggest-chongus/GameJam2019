using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceController : MonoBehaviour
{
    public bool startHidden = false;
    public List<GameObject> WallList;
    public bool hitCentre = false;

    public bool EnterValue = false;
    public bool ExitValue = true;

    // Start is called before the first frame update
    void Start(){
        GameObject Parent = transform.parent.gameObject;

        foreach (Transform child in Parent.transform){

            //fuck you Kenny
            if (child.tag == "wall_disappear"){
                WallList.Add(child.gameObject);

                if (child.name.Contains("desk")){
                    foreach (Transform grandchild in child){
                        WallList.Add(grandchild.gameObject);

                        if (grandchild.name == "chairDesk"){
                            WallList.Add(grandchild.GetChild(0).gameObject);
                        }
                    }
                }

            }
        }

        if (startHidden == true){
            EnterValue = true;
            ExitValue = false;

            Exit();
        }

        else if (startHidden == false){
            EnterValue = false;
            ExitValue = true;
        }

        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void Enter(){

        //make walls disappear
        foreach (GameObject child in WallList){
            child.GetComponent<Renderer>().enabled = EnterValue;
        }

    }

    public void Exit(){

        // make walls reappear
        foreach (GameObject child in WallList)
        {
            child.GetComponent<Renderer>().enabled = ExitValue;
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        // when player hits middle collider
        hitCentre = true;
        print("centre is hit");
    }

}
