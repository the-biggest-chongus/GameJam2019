using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pzlWin : MonoBehaviour
{

    // Flag 

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
            GameObject Flags = GameObject.Find("GameWinCond");
            GWC _flag = Flags.GetComponent<GWC>();
            _flag.w1 = true;
         
        }
        else if (col.CompareTag("win2"))
        {
            GameObject Flags = GameObject.Find("GameWinCond");
            GWC _flag = Flags.GetComponent<GWC>();
            _flag.w2 = true;
        }
        else if (col.CompareTag("win3"))
        {
            GameObject Flags = GameObject.Find("GameWinCond");
            GWC _flag = Flags.GetComponent<GWC>();
            _flag.w3 = true;
        }
        else if (col.CompareTag("win4"))
        {
            GameObject Flags = GameObject.Find("GameWinCond");
            GWC _flag = Flags.GetComponent<GWC>();
            _flag.w4 = true;
        }
        else if (col.CompareTag("win5"))
        {
            GameObject Flags = GameObject.Find("GameWinCond");
            GWC _flag = Flags.GetComponent<GWC>();
            _flag.w5 = true;
        }

       
    }
    // Don't forget to set the variables to false when your object exits the triggers!
    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("win1"))
        {
            GameObject Flags = GameObject.Find("GameWinCond");
            GWC _flag = Flags.GetComponent<GWC>();
            _flag.w1 = false;

        }
        if (col.CompareTag("win2"))
        {
            GameObject Flags = GameObject.Find("GameWinCond");
            GWC _flag = Flags.GetComponent<GWC>();
            _flag.w2 = false;
        }
        if (col.CompareTag("win3"))
        {
            GameObject Flags = GameObject.Find("GameWinCond");
            GWC _flag = Flags.GetComponent<GWC>();
            _flag.w3 = false;
        }
        if (col.CompareTag("win4"))
        {
            GameObject Flags = GameObject.Find("GameWinCond");
            GWC _flag = Flags.GetComponent<GWC>();
            _flag.w4 = false;
        }
        if (col.CompareTag("win5"))
        {
            GameObject Flags = GameObject.Find("GameWinCond");
            GWC _flag = Flags.GetComponent<GWC>();
            _flag.w5 = false;
        }
    }
}
