using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [Header("Bullet Data")]
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    [SerializeField] private float knockbackPower;
    [SerializeField] private float knockTime;

    [Header("Component")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private RangeWeaponController weap ;

    [Header("Effect")]
    [SerializeField] private GameObject hitEft;
    
    void Update()
    {     
        rb.velocity = transform.right * speed;
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
        {
            gameObject.SetActive(false);
           // Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Rigidbody2D enemy  = other.GetComponent<Rigidbody2D>();
            Vector2 different = enemy.transform.position - transform.position;
            different = different.normalized * knockbackPower;
            enemy.AddForce(different, ForceMode2D.Impulse);
            StartCoroutine(Knockback(enemy));

            other.GetComponent<EnemyController>().GetDamage(damage);
            Instantiate(hitEft, other.transform.position, Quaternion.identity); 
            
        } 
        if(other.tag != "Player")
        {
            rb.velocity = Vector2.zero;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
        
    }

    private IEnumerator Knockback(Rigidbody2D enemy)
    {
        if(enemy != null)
        {
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
        }
    }

    public void Updamage(int bonusDmg)
    {
        damage += bonusDmg;
    }
}
