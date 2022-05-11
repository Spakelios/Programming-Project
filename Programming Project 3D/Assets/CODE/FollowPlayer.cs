using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    
    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    
    //States
    public float sightRange;
    public float proximity;
    public float AudibleRange;
   
    public bool playerInSightRange;
    public bool playerIsNear;
    public bool playerIsAudible;
    

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight 
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerIsNear = Physics.CheckSphere(transform.position, proximity, whatIsPlayer);
        playerIsAudible = Physics.CheckSphere(transform.position, AudibleRange, whatIsPlayer);
        

        if (!playerInSightRange && !playerIsNear && !playerIsAudible)
        {
            Patroling();
            AudibleRange++;
        }
        else if (playerInSightRange  && playerIsAudible)
        {
            ChasePlayer();
            AudibleRange++;
        }
        else if (playerIsNear)
        {
            ChasePlayer();
            AudibleRange++;
        }
        else if(playerIsAudible)
        {
            LookAtPlayer();
            AudibleRange++;
        }
    }
    
    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void LookAtPlayer()
    {
        transform.LookAt(player);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, proximity);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, AudibleRange);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, walkPointRange);
    }
}