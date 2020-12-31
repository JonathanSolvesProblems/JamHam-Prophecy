using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;

    private Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    // AI States
    // patroling

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    // state chasing

    public float timeBetweenAttacks;
    bool alreadyAttacked;

    // state attacking
    public float sightRange, attackRange;
    public bool playerInsightRange, playerInAttackRange;

    private Animator anim;

    // ----------

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        playerInsightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInsightRange && !playerInAttackRange) Patrolling();
        if (!playerInsightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInsightRange) AttackPlayer();

        if(CheckDistance())
            SceneManager.LoadScene(2);
    }

    private bool CheckDistance()
    {
        float distance = Vector3.Distance(agent.transform.position, player.transform.position);

        if (distance <= 1.8)
            return true;

        return false;
    }

    private void Patrolling()
    {
        anim.SetBool("isRunning", false);
        anim.SetBool("isAttack", false);

        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        anim.SetBool("isRunning", true);
        anim.SetBool("isAttack", false);
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        anim.SetBool("isRunning", false);
        anim.SetBool("isAttack", true);

        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            // add type of attack code here, shooting, sword, etc.
            // Can add melee here or magic spells 

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
