using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [Header("Bullet Data")]
    [SerializeField] protected int damage;
    [SerializeField] protected float speed;
    [SerializeField] protected float lifeTime;
    [SerializeField] protected float knockbackPower;
    [SerializeField] protected float knockTime;
    private float lifeTimeCD;

    [Header("Component")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Effect")]
    [SerializeField] protected GameObject hitEft;

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
        Damage(other);
    }

    protected virtual void Damage(Collider2D other) { }
    public void Updamage(int bonusDmg)
    {
        damage += bonusDmg;
    }

    protected void DamagePopup(Vector3 position, int atk)
    {
        GameObject g = BulletPool.instance.effectPool.GetObject("Damage Popup");
        g.transform.position = position;
        g.GetComponent<DamagePopup>().Setup(atk);
    }

    public void Setup(int damage)
    {
        this.damage = damage;
    }
}
