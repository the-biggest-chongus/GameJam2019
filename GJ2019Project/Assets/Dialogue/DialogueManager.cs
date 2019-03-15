using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Dialogue Manager: handles the dialogue box
// - Makes the dialogue box visible and invisible
// - Queues different dialogue strings into the dialogue box
public class DialogueManager : MonoBehaviour {

    public Text nameText;	    	//name of person
    public Text dialogueText;       	//what the person says
    public Text option1;	    	//option1 button text
    public Text option2;	    	//option2 button text

    public npcManager npcM;         	//global npc manager

    public Animator animator;	    	//animator for dialogue box
    public Animator optionAnimator; 	//animator for options

    private Queue<string> sentences;	//sentence queue
    private Dialogue dialogue;      	//dialogue which will contain the sentences and name
    private int sentenceCount = 0;  	//how many sentences to read
    private GameObject npc;		//which npc to initialize
    private bool hasoption = false;	//does the npc have options?


    void Start () {
		sentences = new Queue<string>();
    }

	public void StartDialogue (GameObject npc, Dialogue dialogue)
	{
        if (!dialogue.isresolved)
        {
            sentenceCount = 0;
            this.npc = npc;
            this.dialogue = dialogue;

            option1.text = dialogue.choice1;
            option2.text = dialogue.choice2;

            animator.SetBool("IsOpen", true);
            nameText.text = dialogue.name;

            sentences.Clear();

            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }

            DisplayNextSentence();
        }
	}

	public void DisplayNextSentence ()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

        if (sentenceCount == dialogue.questionSentence && dialogue.hasChoice)
        {
            optionAnimator.SetBool("isOptionOpen", true);
            hasoption = true;
        }

        sentenceCount++;

        string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	void EndDialogue()
	{
        if (!hasoption)
        {
            npcM.resolve(npc);
        }
		animator.SetBool("IsOpen", false);
    }

    public void Button1Clicked()
    {
        if(dialogue.correctChoice == 1)
        {
            correctAnswer();
        }
        else
        {
            incorrectAnswer();
        }
    }

    public void Button2Clicked()
    {
        if (dialogue.correctChoice == 2)
        {
            correctAnswer();
        }
        else
        {
            incorrectAnswer();
        }
    }

    private void correctAnswer()
    {
        optionAnimator.SetBool("isOptionOpen", false);
        foreach (string sentence in dialogue.resolve)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();

        npcM.resolve(npc);
        dialogue.isresolved = true;
    }

    private void incorrectAnswer()
    {
        optionAnimator.SetBool("isOptionOpen", false);
        foreach (string sentence in dialogue.notresolve)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

}
