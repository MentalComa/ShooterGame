using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    

    public List<Transform> patrolPoints;

    private NavMeshAgent _navMeshAgent;

    public PlayerController player;

    public float viewAngle;

    public float damage = 30;

    private PlayerHealth _playerHealth;

    private bool _isPlayerNoticed;

    public Animator animator;

    public float AttackDistance = 1;

    private EnemyHealth _enemyHealth;
    public bool IsAlive()
    {
        return _enemyHealth.IsAlive();
    }
    // Start is called before the first frame update
    void Start()
    {
        InitComponentLinks();

        PickNewPatrolPoint();

        
    }

    // Update is called once per frame
    void Update()
    {

        NoticePlayerUpdate();

        ChaseUpdate();

        AttackUpdate();

        PatrolUpdate();

    }
    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }
    private void PatrolUpdate()
    {
        if (!_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                PickNewPatrolPoint();
            }
        }
    }
    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerHealth = player.GetComponent<PlayerHealth>();
        _enemyHealth = GetComponent<EnemyHealth>();
    }
    private void NoticePlayerUpdate()
    {
       
        _isPlayerNoticed = false;
        if (!_playerHealth.IsAlive()) return;

        var direction = player.transform.position - transform.position;

        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }

            }

        }
    }
    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }
    }
   
    private void AttackUpdate()
    {
        if (_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                animator.SetTrigger("Attack");
                //_playerHealth.GetComponent<PlayerHealth>().DealDamage(damage * Time.deltaTime);
            }
        }
    }
    public void AttackDamage()
    { 
        if (!_isPlayerNoticed) return;
        if (_navMeshAgent.remainingDistance > (_navMeshAgent.stoppingDistance + AttackDistance)) return;
            _playerHealth.DealDamage(damage);
    }
}
