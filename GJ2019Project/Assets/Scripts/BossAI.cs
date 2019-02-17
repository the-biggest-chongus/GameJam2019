using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{
    private float speed = 5f;

    public GameObject player;
    private bool TIMETORAGE = false;
    private bool initialMeeting = true;

    public Transform middleOfBossRoom;

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
        GetComponent<NavMeshAgent>().speed = this.speed;
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

    private void beginRage()
    {
        speed = 25f;
        GetComponent<NavMeshAgent>().speed = this.speed;
        CancelInvoke("walkAround");
        TIMETORAGE = true;
        walkAround();
    }

    private void rageInABit()
    {
        Invoke("rage", timeUntilRage);
    }

    private void walkAround()
    {
        if (TIMETORAGE)
        {
            //animator.SetBool("walking", true);
            //float randomX = Random.Range(0, 50);
            //float randomZ = Random.Range(0, 50);
            //Vector3 randomDestination = new Vector3(randomX, 0f, randomZ);
            Vector3 randomDestination = getPositionNearPlayer();


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
        else // walk around broodingly, thinking about your bad employees
        {
            Vector3 bossRoom = middleOfBossRoom.position;
            float wanderX = Random.Range(bossRoom.x - 50f, bossRoom.x + 50f);
            float wanderZ = Random.Range(bossRoom.z - 50f, bossRoom.z + 50f);

            Vector3 randomDestination = new Vector3(wanderX, transform.position.y, wanderZ);
            GetComponent<NavMeshAgent>().isStopped = false;
            GetComponent<NavMeshAgent>().destination = randomDestination;
            Invoke("walkAround", 3f);
        }
        
    }

    private Vector3 getPositionNearPlayer()
    {
        Vector3 playerPos = player.transform.position;
        float playerX = playerPos.x;
        float playerZ = playerPos.z;
        float radius = 5f;

        float randomXNearPlayer = Random.Range(playerX - radius, playerX + radius);
        float randomZNearPlayer = Random.Range(playerZ - radius, playerZ + radius);

        return new Vector3(randomXNearPlayer, playerPos.y, randomZNearPlayer);
    }

    private void turnTowardsPlayer()
    {
        Vector3 newDir = Vector3.RotateTowards(transform.forward, player.transform.position, 500, 0.0f);

        // Move our position a step closer to the target.
        transform.rotation = Quaternion.LookRotation(newDir);
    }

    private void rage()
    {
        int chosenAttack = 3;
        if (initialMeeting == false)
        {
            chosenAttack = Random.Range(1, 4);
        }
        print(chosenAttack);

        if (chosenAttack == 1 && bossFeelings == BossState.WALKING)
        {
            bossFeelings = BossState.RAGING;
            animator.SetBool("raging", true);
            animator.SetBool("walking", false);
            turnTowardsPlayer();
        } else if (chosenAttack == 2 && bossFeelings == BossState.WALKING)
        {
            bossFeelings = BossState.REPRIMAND;
            animator.SetBool("reprimand", true);
            animator.SetBool("walking", false);
            turnTowardsPlayer();
            mouth.calculatedBarrage();
        } else if (chosenAttack == 3 && bossFeelings == BossState.WALKING)
        {
            bossFeelings = BossState.GLARE;
            turnTowardsPlayer();
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

    public void noticeTheTooCheerfulEmployeeAndCrushThem()
    {
        beginRage();
    }
}
