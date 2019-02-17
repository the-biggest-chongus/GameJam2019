using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{
    public BossMouth mouth;
    private float timeUntilRage = 3f;
    [SerializeField]
    private BossState bossFeelings = BossState.WALKING;
    private Animator animator;

    private enum BossState
    {
        WALKING,
        RAGING,
        REPRIMAND,
        GLARE
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rageInABit();
        walkAround();
    }

    // Update is called once per frame
    void Update()
    {
        if (bossFeelings == BossState.WALKING)
        {
            
        }
        else if (bossFeelings == BossState.RAGING)
        {
            spinLikeCrazy();
            angrySpewing();
        } else if (bossFeelings == BossState.REPRIMAND)
        {

        } else if (bossFeelings == BossState.GLARE)
        {

        }
    }

    private void rageInABit()
    {
        Invoke("rage", timeUntilRage);
    }

    private void walkAround()
    {
        //animator.SetBool("walking", true);
        float randomX = Random.Range(0, 50);
        float randomZ = Random.Range(0, 50);
        Vector3 randomDestination = new Vector3(randomX, 0f, randomZ);

        /*
        switch (randomDirection)
        {
            case 1:
                randomDestination = new Vector3(0,0,0);
                print(Vector3.forward);
                break;
            case 2:
                print("2");
                randomDestination = new Vector3(35, 0, 35);
                break;
        }
        */
        GetComponent<NavMeshAgent>().isStopped = false;
        GetComponent<NavMeshAgent>().destination = randomDestination;
        rageInABit();
    }

    private void rage()
    {
        int chosenAttack = Random.Range(1, 4);
        print(chosenAttack);

        if (chosenAttack == 1 && bossFeelings == BossState.WALKING)
        {
            bossFeelings = BossState.RAGING;
            animator.SetBool("raging", true);
            animator.SetBool("walking", false);
        } else if (chosenAttack == 2 && bossFeelings == BossState.WALKING)
        {
            bossFeelings = BossState.REPRIMAND;
            animator.SetBool("reprimand", true);
            animator.SetBool("walking", false);
            mouth.calculatedBarrage();
        } else if (chosenAttack == 3 && bossFeelings == BossState.WALKING)
        {
            bossFeelings = BossState.GLARE;
            mouth.piercingLanguage();
        }

        GetComponent<NavMeshAgent>().isStopped = true;
        Invoke("stopRaging", 4f);
    }

    private void spinLikeCrazy()
    {
        transform.Rotate(Vector3.up * 1000f * Time.deltaTime, Space.World);
    }

    private void angrySpewing()
    {
        mouth.crazySpewing();
    }

    private void stopRaging()
    {
        if (bossFeelings == BossState.RAGING)
        {
            stopSpewing();
            // spinning will stop once out of raging state
            bossFeelings = BossState.WALKING;
            animator.SetBool("raging", false);
            animator.SetBool("walking", true);
        } else if (bossFeelings == BossState.REPRIMAND)
        {
            stopReprimanding();
            bossFeelings = BossState.WALKING;
            animator.SetBool("reprimand", false);
            animator.SetBool("walking", true);
        }
        else if (bossFeelings == BossState.GLARE)
        {
            stopPiercing();
            bossFeelings = BossState.WALKING;
        }
    }

    private void stopSpewing()
    {
        mouth.stopCrazySpewing();
        walkAround();
    }

    private void stopReprimanding()
    {
        mouth.stopCalculatedBarrage();
        walkAround();
    }

    private void stopPiercing()
    {
        mouth.stopPiercingLanguage();
        walkAround();
    }
}
