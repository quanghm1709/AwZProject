using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy Data Core")]
    [SerializeField] public int level;
    [SerializeField] public int maxHp;
    [SerializeField] public float maxSpeed;
    [HideInInspector] public int currentHp;
    [HideInInspector] public float currentSpeed;
    [SerializeField] public bool canMove = true;

    [Header("Component")]
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public Animator anim;
    [SerializeField] private GameObject[] itemToDrop;

    public void GetDamage(int damage)
    {
        GameObject goldPool = GameObject.Find("Gold Pool");

        currentHp -= damage;
        if(currentHp <= 0)
        {
            //Instantiate(itemToDrop[Random.Range(0, itemToDrop.Length)], transform.position, transform.rotation);
            GameObject g = goldPool.GetComponent<ObjectPool>().GetObject(itemToDrop[0].name);
            g.transform.position = transform.position;
            
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
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

    public void Reset()
    {
        currentHp = maxHp;
    }
}
