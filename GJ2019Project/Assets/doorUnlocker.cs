using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorUnlocker : MonoBehaviour
{
    public int doorKey;
    public bool unlockDoor;

    public npcManager npcM;

    private void OnTriggerStay(Collider other)
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (unlockDoor)
            {
                npcM.items[doorKey] = true;
            }

        }

    }
}
