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
    private float lifeTimeCD;

    [Header("Component")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private RangeWeaponController weap ;

    [Header("Effect")]
    [SerializeField] private GameObject hitEft;

    private void Start()
    {
        lifeTimeCD = lifeTime;   
    }

    void Update()
    {     
        rb.velocity = transform.right * speed;
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
        {
            lifeTime = lifeTimeCD;
            gameObject.SetActive(false);
           // Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        lifeTime = lifeTimeCD;
        if (other.tag == "Enemy")
        {
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();

            Vector2 different = enemy.transform.position - transform.position;
            different = different.normalized * knockbackPower;
            enemy.AddForce(different, ForceMode2D.Impulse);

            other.GetComponent<EnemyController>().GetDamage(damage);

            GameObject hitEff = BulletPool.instance.bulletPool.GetObject(hitEft.name);
            hitEff.transform.position = transform.position;
        } 
        if(other.tag != "Player")
        {         
            gameObject.SetActive(false);
        }
        transform.position = GameObject.Find("Player").transform.position;

    }

    public void Updamage(int bonusDmg)
    {
        damage += bonusDmg;
    }
}
