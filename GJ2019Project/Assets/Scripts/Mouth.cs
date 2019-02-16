using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouth : MonoBehaviour
{
    public GameObject words;

    private bool speakingAngrily = false;

    // Start is called before the first frame update
    public virtual void Start()
    {
        startSpeakingAngryWords(1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void startSpeakingAngryWords(float frequency)
    {
        if (!speakingAngrily) { 
            InvokeRepeating("speakAngryWords", 0f, frequency);
            speakingAngrily = true;
        }
    }

    protected void stopSpeakingAngryWords()
    {
        
            CancelInvoke("speakAngryWords");
        
    }

    private void speakAngryWords()
    {
        Instantiate(words, transform.position, transform.rotation);
    }
}
