using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public GameObject boss;

    private int level = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            level++;
            if (level == 1)
            {
                boss.GetComponent<BossAI>().noticeTheTooCheerfulEmployeeAndCrushThem();
            }
            else if (level == 2)
            {
                boss.GetComponent<BossAI>().finalBattle();
            }
            
        }
    }
}
