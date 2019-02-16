using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouth : MonoBehaviour
{
    public GameObject words;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("speakAngryWords", 3f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void speakAngryWords()
    {
        Instantiate(words, transform.position, transform.rotation);
    }
}
