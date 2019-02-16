using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{
    public BossMouth mouth;
    private float timeUntilRage = 100f;
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
        Invoke("rage", timeUntilRage);
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

    private void walkAround()
    {
        animator.SetTrigger("walking");
        //float randomX = Random.Range(-100f, 100f);
        //float randomZ = Random.Range(-100f, 100f);
        Vector3 randomDestination = Vector3.forward;
        print(randomDestination);

        GetComponent<NavMeshAgent>().destination = randomDestination;
    }

    private void rage()
    {
        bossFeelings = BossState.RAGING;
        animator.SetTrigger("raging");
    }

    private void spinLikeCrazy()
    {
        transform.Rotate(Vector3.up * 1000f * Time.deltaTime, Space.World);
    }

    private void angrySpewing()
    {
        mouth.crazySpewing();
    }
}
