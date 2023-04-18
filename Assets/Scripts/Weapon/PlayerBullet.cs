using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : BulletController
{
    public enum bulletType { BURN, PIERCE, SUPER_PIERCE, SLOW, BLOW, RADIATE, NORMAL }

    public bulletType type;

    protected override void Damage(Collider2D other)
    {
        
        if (other.tag == "Enemy")
        {
            switch (type)
            {
                case bulletType.BURN:
                    {
                        break;
                    }
                case bulletType.PIERCE:
                    {
                        break;
                    }
                case bulletType.SUPER_PIERCE:
                    {
                        break;
                    }
                case bulletType.SLOW:
                    {
                        //Slow_Bullet(other);
                        StartCoroutine(DelayedEvent(2));
                        break;
                    }
                case bulletType.BLOW:
                    {
                        break;
                    }
                case bulletType.RADIATE:
                    {
                        break;
                    }
                case bulletType.NORMAL:
                    {
                        Normal_Bullet(other);
                        break;
                    }
            }
            
        }
        if (other.tag != "Player")
        {
            //gameObject.SetActive(false);
        }
        transform.position = GameObject.Find("Player").transform.position;
    }


    void Normal_Bullet(Collider2D other)
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

    void Slow_Bullet(Collider2D other)
    {
        //Debug.Log("a");
        //StartCoroutine(DelayedEvent(10));
        //Debug.Log("b");
    }

    IEnumerator DelayedEvent(int timedelay)
    {
        Debug.Log("a");
        yield return new WaitForSeconds(timedelay);
        Debug.Log("b");
    }
}
