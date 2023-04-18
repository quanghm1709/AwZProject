using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemy : EnemyController
{     
    protected override void Attack()
    {
        Collider2D[] hit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);
        if (hit != null)
        {
            foreach (Collider2D h in hit)
            {
                if (h.tag == "Player")
                {
                    canMove = false;
                    if (timeBtwAtk <= 0)
                    {
                        PlayerController.instance.GetDamage(currentAtk);
                        timeBtwAtk = timeBtwAttack;
                        anim.SetBool("isAttack", true);
                    }
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

        if (timeBtwAtk > 0)
        {
            timeBtwAtk -= Time.deltaTime;
        }      
    }

    protected override IEnumerator GetHit()
    {
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(.1f);
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(.54f, 1, .67f, 1);
    }
}
