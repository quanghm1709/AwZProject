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
                        Burn_Bullet(other);
                        break;
                    }
                case bulletType.PIERCE:
                    {
                        Pierce(other);
                        break;
                    }
                case bulletType.SUPER_PIERCE:
                    {
                        Super_Pierce(other);
                        break;
                    }
                case bulletType.SLOW:
                    {
                        Slow_Bullet(other);
                        break;
                    }
                case bulletType.BLOW:
                    {
                        Blow(other);
                        break;
                    }
                case bulletType.RADIATE:
                    {
                        Radiate(other);
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
        
    }

    void Burn_Bullet(Collider2D other)
    {
       
    }

    void Pierce(Collider2D other)
    {

    }

    void Super_Pierce(Collider2D other)
    {

    }

    void Radiate(Collider2D other)
    {

    }

    void Blow(Collider2D other)
    {

    }



    IEnumerator DelayedEvent(int timedelay)
    {
        Debug.Log("a");
        yield return new WaitForSeconds(timedelay);
        Debug.Log("b");
    }
}
