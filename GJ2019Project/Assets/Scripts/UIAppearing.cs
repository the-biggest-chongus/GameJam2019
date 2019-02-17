using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAppearing : MonoBehaviour
{
    public GameObject menu;
    void Start()
    {
        menu.SetActive(false);
    }

    

    void OnTriggerEnter(Collider coll)
    {
        print("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
        if (coll.gameObject.tag == "Player")
        {
            print("BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB");
            if (menu.activeSelf)
            {
               menu.SetActive(false);
            }
            else
            {
                menu.SetActive(true);
            }
            
        }
    }
}
