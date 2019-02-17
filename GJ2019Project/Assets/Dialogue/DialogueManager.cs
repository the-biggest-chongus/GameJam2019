using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;
    public Text option1;
    public Text option2;

    public npcManager npcM;

	public Animator animator;
    public Animator optionAnimator;

    private Queue<string> sentences;
    private Dialogue dialogue;
    private int sentenceCount = 0;
    private GameObject npc;

    // Use this for initialization
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
