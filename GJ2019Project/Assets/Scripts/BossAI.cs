using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    public BossMouth mouth;
    private float timeUntilRage = 10f;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (bossFeelings == BossState.WALKING)
        {
            walkAround();
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
