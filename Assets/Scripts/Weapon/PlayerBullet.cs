using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : BulletController
{
    protected override void Damage(Collider2D other)
    {
        base.Damage(other);
        if (other.tag == "Enemy")
        {
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();

            if (other.GetComponent<EnemyController>().currentHp > 1)
            {
                Vector2 different = enemy.transform.position - transform.position;
                different = different.normalized * knockbackPower;
                enemy.AddForce(different, ForceMode2D.Impulse);
            }

            other.GetComponent<EnemyController>().GetDamage(damage);

            GameObject hitEff = BulletPool.instance.effectPool.GetObject(hitEft.name);
            hitEff.transform.position = transform.position;

            DamagePopup(other.transform.position, damage);
        }
        if (other.tag != "Player")
        {
            gameObject.SetActive(false);
        }
        transform.position = GameObject.Find("Player").transform.position;
    }
}
