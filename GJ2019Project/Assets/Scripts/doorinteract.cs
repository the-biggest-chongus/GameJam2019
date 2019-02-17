using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorinteract : MonoBehaviour
{
    int happyState = 0;
    public GameObject heartParticles;

    public DialogueManager dialogueManager;
    public GameObject attention;

    public npcManager npcm;

    private DialogueTrigger dialogueTrigger;
    private bool activeAttention = true;

    // Start is called before the first frame update
    void Start()
    {
        dialogueTrigger = this.GetComponent<DialogueTrigger>();
        attention.GetComponent<Renderer>().enabled = false;
    }

    public void triggerActive()
    {
        activeAttention = true;
    }

    private void OnTriggerExit(Collider other)
    {
        attention.GetComponent<Renderer>().enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (activeAttention)
        {
            attention.GetComponent<Renderer>().enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (npcm.unlockdoor(this.gameObject))
            {
                this.gameObject.SetActive(false);
                attention.GetComponent<Renderer>().enabled = false;
                activeAttention = false;
            }
            else
            {
                dialogueTrigger.TriggerDialogue(this.gameObject);
            }
            
        }

    }
}
