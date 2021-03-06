﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionNPC : MonoBehaviour
{
    int happyState = 0;
    public GameObject heartParticles;

    public DialogueManager dialogueManager;
    public GameObject attention;

    private DialogueTrigger dialogueTrigger;
    private bool activeAttention = true;

    // Start is called before the first frame update
    void Start()
    {
        dialogueTrigger = this.GetComponent<DialogueTrigger>();

        //attention.GetComponent<Renderer>().enabled = false;
    }

    public void triggerActive()
    {
        activeAttention = true;
    }

    private void OnTriggerExit(Collider other)
    {
        //attention.GetComponent<Renderer>().enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (activeAttention)
        {
            //attention.GetComponent<Renderer>().enabled = true;
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            dialogueTrigger.TriggerDialogue(this.gameObject);
            //print("happy state");
            //happyState = 1;
            //GameObject particlePlaced = Instantiate(heartParticles, transform.position + new Vector3(0, 0.7f, 0), Quaternion.identity);
            //particlePlaced.transform.parent = gameObject.transform;
            //particlePlaced.transform.localScale = new Vector3(1, 1, 1);
            activeAttention = false;
        }

    }
}
