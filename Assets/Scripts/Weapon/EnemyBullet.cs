using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : BulletController
{
    protected override void Damage(Collider2D other)
    {
        base.Damage(other);
        if (other.tag == "Player")
        {
            PlayerController.instance.GetDamage(damage);

            GameObject hitEff = BulletPool.instance.effectPool.GetObject(hitEft.name);
            hitEff.transform.position = transform.position;

            DamagePopup(other.transform.position, damage);
        }
        if (other.tag != "Enemy")
        {
            gameObject.SetActive(false);
        }
    }
}
