using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombZombie : EnemyController
{
    [SerializeField] protected string explosionEffect;

    protected override void Attack()
    {
        float distance = Vector3.Distance(transform.position, PlayerController.instance.transform.position);

        if (distance <= attackRange)
        {
            canMove = false;
            if (timeBtwAtk > 0)
            {
                timeBtwAtk -= Time.deltaTime;
            }
            else
            {
                anim.SetBool("isAttack", true);
                StartCoroutine(Explosion());
            }
        }
        else
        {
            canMove = true;
            anim.SetBool("isAttack", false);
        }
    }

    private IEnumerator Explosion()
    {
        yield return new WaitForSeconds(.3f);

        Collider2D[] hit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);
        if (hit != null)
        {
            foreach (Collider2D h in hit)
            {
                if (h.tag == "Player")
                {
                    PlayerController.instance.GetDamage(currentAtk);
                    GameObject g = BulletPool.instance.effectPool.GetObject(explosionEffect);
                    g.transform.position = attackPoint.position;

                    gameObject.SetActive(false);
                }
            }
        }
    }

    protected override IEnumerator GetHit()
    {
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(.1f);
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(.54f, 1, .67f, 1);
    }
}
