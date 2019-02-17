using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pzlWin : MonoBehaviour
{

    // Flag 
    private bool t1;
    private bool t2;
    private bool t3;
    private bool t4;
    private bool t5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("win1"))
        {
            t1 = true;
            Debug.Log(t1);
        }
        else if (col.CompareTag("win2"))
        {
            t2 = true;
        }
        else if (col.CompareTag("win3"))
        {
            t3 = true;
        }
        else if (col.CompareTag("win4"))
        {
            t4 = true;
        }
        else if (col.CompareTag("win5"))
        {
            t5 = true;
        }

        if (t1 && t2 && t3 && t4 && t5)
        {
            Debug.Log("You fucking win this god damn  shitty ass puzzle game congratz");
            // Do shit when you win 

        }
    }
    // Don't forget to set the variables to false when your object exits the triggers!
    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("win1"))
        {
            t1 = false;
            Debug.Log(t1);

        }
        if (col.CompareTag("win2"))
        {
            t2 = false;
        }
        if (col.CompareTag("win3"))
        {
            t3 = false;
        }
        if (col.CompareTag("win4"))
        {
            t4 = false;
        }
        if (col.CompareTag("win5"))
        {
            t5 = false;
        }
    }
}
