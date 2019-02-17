using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GWC : MonoBehaviour
{

    public bool w1;
    public bool w2;
    public bool w3;
    public bool w4;
    public bool w5;


    // Start is called before the first frame update
    void Start()
    {
    bool w1 = false;
    bool w2 = false;
    bool w3 = false;
    bool w4 = false;
    bool w5 = false;

    }

    // Update is called once per frame
    void Update()
    {
       

        if (w1 && w2 && w3 && w4 && w5)
        {
            Debug.Log("You fucking win this god damn  shitty ass puzzle game congratz");
            // Do shit when you win 

        }

    }


}
