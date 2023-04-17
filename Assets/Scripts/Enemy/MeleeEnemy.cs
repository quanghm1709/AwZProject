using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemy : EnemyController
{
    [Header("Data")]
    [SerializeField] private int maxAtk;
    [SerializeField] private float damageRange;
    [SerializeField] private float timeBtwAttack;
    private int currentAtk;
    private float timeBtwAtk;
    private bool canAttack;

    [Header("Component")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange;
    [SerializeField] private NavMeshAgent agent;

    private Vector3 moveDirection;
    private void Start()
    {
        currentAtk = maxAtk;
        timeBtwAtk = timeBtwAttack;

        currentHp = maxHp;
        currentSpeed = maxSpeed;

        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        if (canMove)
        {
            //moveDirection = PlayerController.instance.transform.position - transform.position;
            //rb.velocity = moveDirection * currentSpeed;
            agent.SetDestination(PlayerController.instance.transform.position);
            agent.speed = currentSpeed;
        }
        else
        {
            agent.speed = 0;
            //rb.velocity = Vector2.zero;
        }
        
        Flip();

        Collider2D[] hit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);
        if (hit != null)// && hit.gameObject.tag == "Player")
        {
            //PlayerController.instance.GetDamage(currentAtk);
            foreach(Collider2D h in hit)
            {
                if(h.tag == "Player")
                {
                    canMove = false;
                    Attack();
                }
                else
                {
                    canMove = true;
                    anim.SetBool("isAttack", false);
                }
            }
        }
        else
        {
            canMove = true;
            anim.SetBool("isAttack", false);
        }
        
        if(timeBtwAtk > 0)
        {
            timeBtwAtk -= Time.deltaTime;
        }
    }

    private void Attack()
    {
        if(timeBtwAtk <= 0)
        {
            PlayerController.instance.GetDamage(currentAtk);
            timeBtwAtk = timeBtwAttack;
            anim.SetBool("isAttack", true);
        }
    }
    void OnDrawGizmosSelected()
    {
        //Gizmos.color = Color.red;
       // Gizmos.DrawSphere(attackPoint.position, attackRange);
    }

}
