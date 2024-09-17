using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : EnemyController
{
    [SerializeField] private string enemyBullet;

    protected override void Attack()
    {
        float distance = Vector3.Distance(transform.position, PlayerController.instance.transform.position);

        if(distance <= attackRange)
        {
            canMove = false;
            if (timeBtwAtk > 0)
            {
                timeBtwAtk -= Time.deltaTime;
            }
            else
            {
                anim.SetBool("isAttack", true);
                StartCoroutine(Fire());
            }
        }
        else
        {
            canMove = true;
            anim.SetBool("isAttack", false);
        }
    }

    private IEnumerator Fire()
    {
        Vector2 lookDir = PlayerController.instance.transform.position - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        attackPoint.rotation = Quaternion.Euler(0, 0, angle);

        timeBtwAtk = timeBtwAttack + .3f;
        yield return new WaitForSeconds(.3f);
        GameObject g = BulletPool.instance.enemyBulletPool.GetObject(enemyBullet);
        g.transform.position = attackPoint.position;
        g.transform.rotation = attackPoint.rotation;
    }
    protected override IEnumerator GetHit()
    {
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(.1f);
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(.915f, .89f, .565f, 1);
    }
}
