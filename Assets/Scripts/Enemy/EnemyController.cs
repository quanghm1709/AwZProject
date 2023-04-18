using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy Data Core")]
    public int level;
    public int maxHp;
    public float maxSpeed;
    public int currentHp;
    public int maxAtk;
    public float damageRange;
    public float timeBtwAttack;
    public int currentAtk;
    public float timeBtwAtk;
    public bool canAttack;

    [HideInInspector] public float currentSpeed;
    [SerializeField] public bool canMove = true;

    [Header("Component")]
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public Animator anim;
    [SerializeField] private GameObject[] itemToDrop;
    [SerializeField] protected NavMeshAgent agent;
    [SerializeField] protected Transform attackPoint;
    [SerializeField] protected float attackRange;

    [Header("UI")]
    [SerializeField] protected Slider hpBar;

    private void Start()
    {
        currentAtk = maxAtk;
        timeBtwAtk = timeBtwAttack;

        currentHp = maxHp;
        currentSpeed = maxSpeed;

        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        Move();

        Flip();

        Attack();

        UpdateHpUI();
    }
    
    public void GetDamage(int damage)
    {
        GameObject goldPool = GameObject.Find("Gold Pool");

        currentHp -= damage;
        if(currentHp <= 0)
        {
            int a = Random.RandomRange(1,100);

            Debug.Log(a);
            GameObject g = goldPool.GetComponent<ObjectPool>().GetObject(itemToDrop[0].name);
            int a = Random.RandomRange(1, 100);
            int b = Random.RandomRange(0, 2);
            if (a > 0)
            {
                GameObject Gun = Instantiate<GameObject>(WeaponManager.DropGunBase);
                Gun.GetComponent<Item>().itemName = GameManager.instance.player_magazine[b].gun_name;
                Gun.transform.position = transform.position;
                Gun.transform.GetChild(1).GetChild(0).GetComponent<SpriteRenderer>().sprite = GameObject.Find("Weapon Manager").GetComponent<WeaponManager>().GetImage(Gun.GetComponent<Item>().itemName).weapUI;
            }

            g.transform.position = transform.position;
            anim.SetBool("isDead", true);
            StartCoroutine(OnDead());
        }
        else
        {
            StartCoroutine(GetHit());
        }

    }

    protected void UpdateHpUI()
    {
        hpBar.maxValue = maxHp;
        hpBar.value = currentHp;
    }

    protected virtual IEnumerator GetHit()
    {
        yield return 0;
    }

    protected IEnumerator OnDead()
    {
        agent.isStopped = true;
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }

    public void Flip()
    {
        if(PlayerController.instance.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        } else if (PlayerController.instance.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    protected virtual void Attack(){ }

    protected void Move()
    {
        if (canMove)
        {
            agent.SetDestination(PlayerController.instance.transform.position);
            agent.speed = currentSpeed;
            agent.isStopped = false;
        }
        else
        {
            agent.speed = 0;
            agent.isStopped = true;
            agent.velocity = Vector3.zero;
        }
    }
    public void Reset()
    {
        currentHp = maxHp;
        agent.isStopped = false;
        anim.SetBool("isDead", false);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
