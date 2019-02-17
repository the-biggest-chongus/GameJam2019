using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string opponentWordTag; // enemy "bullet"

    [SerializeField]
    private int selfEsteem = 100; // health

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == opponentWordTag)
        {
            selfEsteem -= 5;
        }
    }
}
