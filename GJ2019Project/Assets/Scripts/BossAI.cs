using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{
    public BossMouth mouth;
    private float timeUntilRage = 3f;
    private BossState bossFeelings = BossState.WALKING;
    private Animator animator;

    private enum BossState
    {
        WALKING,
        RAGING
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
        }
    }

    private void rageInABit()
    {
        Invoke("rage", timeUntilRage);
    }

    private void walkAround()
    {
        animator.SetTrigger("walking");
        Vector3 randomDestination = Vector3.zero;
        float randomDirection = Random.Range(1, 3);
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

        GetComponent<NavMeshAgent>().destination = randomDestination;
        rageInABit();
    }

    private void rage()
    {
        bossFeelings = BossState.RAGING;
        animator.SetTrigger("raging");
        Invoke("stopRaging", 4f);
    }

    private void spinLikeCrazy()
    {
        GetComponent<NavMeshAgent>().isStopped = true;
        transform.Rotate(Vector3.up * 1000f * Time.deltaTime, Space.World);
    }

    private void angrySpewing()
    {
        mouth.crazySpewing();
    }

    private void stopRaging()
    {
        stopSpewing();
        // spinning will stop once out of raging state
        bossFeelings = BossState.WALKING;
    }

    private void stopSpewing()
    {
        mouth.stopCrazySpewing();
        walkAround();
    }
}
