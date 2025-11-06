using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class EnemyController : MonoBehaviour
{
    public NavMeshAgent enemyAgent;
    public Animator enemyAnimator;
    public Vector2 patrolRange;
    public float patrolTime;
    public Image imgEnemyLife;

    private Transform enemyTransform;
    private Transform playerTransform;
    private EnemyState curreState;
    private Vector3 randomPosition;
    // Start is called before the first frame update
    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent <Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        curreState = EnemyState.PATROL;
        UpdateState(); //Actualizar el estado
    }
    // Update is called once per frame
    void Update()
    {
        if (curreState == EnemyState.CHASE)
        {
            enemyAgent.SetDestination(playerTransform.position);
        }
        enemyAnimator.SetFloat("speed", enemyAgent.velocity.sqrMagnitude);

    }
    private void UpdateState()
    {
        switch (curreState)
        {
            case EnemyState.PATROL:
                InvokeRepeating("GenerateRandomDestination",0f,patrolTime);
                break;
        }
    }
    private void GenerateRandomDestination()
    {
        randomPosition = transform.position + new Vector3(
            Random.Range(-patrolRange.x, patrolRange.x),
            0f,
            Random.Range(-patrolRange.y,patrolRange.y));
        enemyAgent.SetDestination(randomPosition);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (curreState == EnemyState.PATROL)
            { 
            curreState = EnemyState.CHASE;
            CancelInvoke("GenerateRandomDestination");
            }
        }
    }
}

public enum EnemyState
{
    PATROL,
    CHASE,
    ATTACK
};