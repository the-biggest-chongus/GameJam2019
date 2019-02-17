using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public string opponentWordTag; // enemy "bullet"
    public int damageTaken;

    [SerializeField]
    private int selfEsteem = 100; // health

    public Slider healthUI;

    public GameObject damagePanel;

    float lastHitTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("addHealth", 2.0f,2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addHealth()
    {
        if(selfEsteem <= 97)
        {
            selfEsteem += 3;
            Invoke("ResetColor", 0.2f);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == opponentWordTag && lastHitTime + 0.5f < Time.time)
        {
            selfEsteem -= damageTaken;
            healthUI.value -= damageTaken;
            Destroy(other.gameObject);

            if (other.gameObject.tag == "HurtfulWord")
            {
                damagePanel.GetComponent<Image>().color = new Color(0.8f,0,0,0.5f);
                Invoke("ResetColor", 0.2f);
            }
        }
    }
    void ResetColor()
    {
        damagePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
    }
}
