using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [Header("Player Data Core")]
    [SerializeField] private int maxHp;
    [SerializeField] private float maxSpeed;
    [HideInInspector] public int currentHp;
    [HideInInspector] public float currentSpeed;

    [Header("Component")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    //[SerializeField] private Rigidbody2D hand;

    [Header("Radar")]
    private GameObject[] multiEnemy;
    public Transform closetEnemy;

    [Header("Controll")]
    [SerializeField] public Transform joyStickButton;
    [SerializeField] public Transform joyStickLocalPos;
    [SerializeField] private Transform gunArm;

    [Header("Weapon")]
    [SerializeField] public RangeWeaponController currentWeap;
    [SerializeField] public Transform hand;

    [Header("Dash")]
    [SerializeField] private float dashDistance;
    [SerializeField] private float dashDuration;
    private bool isDashing;
    private bool canDash;
    private float dashTime;
    [SerializeField] private LayerMask layerMask;

    [HideInInspector] public bool isFacingRight = true;
    private Vector3 moveInput;
    private float dirX;
    private float dirY;

    //Get Damage
    private bool canGetDmg = true;
    private float timeBtwHurt;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SwapWeap();
        currentHp = maxHp;
        currentSpeed = maxSpeed;
        closetEnemy = null;
        dashTime = dashDuration;
    }

    private void Update()
    {
        //moveInput.x = Input.GetAxisRaw("Horizontal");
        //moveInput.y = Input.GetAxisRaw("Vertical");

        dirX = CrossPlatformInputManager.GetAxisRaw("Horizontal") * currentSpeed;
        dirY = CrossPlatformInputManager.GetAxisRaw("Vertical") * currentSpeed;
        moveInput = new Vector3(dirX, dirY).normalized;

        if (dirX != 0 || dirY != 0)
        {
            anim.SetBool("isMove", true);
        }
        else
        {
            anim.SetBool("isMove", false);
        }

        if (CrossPlatformInputManager.GetButtonDown("Dash") || Input.GetKeyDown(KeyCode.Q))
        {
            Dash();
        }
        
        UIController.instance.dashCD.maxValue = dashTime;
        UIController.instance.dashCD.value = dashDuration;

       closetEnemy = getClosetEnemy();

        if (timeBtwHurt > 0)
        {
            canGetDmg = false;
            timeBtwHurt -= Time.deltaTime;
        }
        else
        {
            canGetDmg = true;
        }

        UIController.instance.hpBar.value = currentHp;
        UIController.instance.hpBar.maxValue = maxHp;

        if(dashDuration > 0)
        {
            canDash = false;
            dashDuration -= Time.deltaTime;
        }
        else
        {
            canDash = true;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            GetDamage(1);
        }
    }

    internal void Revive()
    {
        currentHp = maxHp;
    }

    private void FixedUpdate()
    {
        //rb.velocity = moveInput * currentSpeed;
        rb.velocity = new Vector2(dirX, dirY);
        if (closetEnemy != null)
        {
            Vector2 lookDir = closetEnemy.position - transform.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            gunArm.rotation = Quaternion.Euler(0, 0, angle);
        }
        else
        {
            if (dirX != 0)
            {
                Vector2 lookDir = joyStickButton.position - joyStickLocalPos.position;
                float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
                gunArm.rotation = Quaternion.Euler(0, 0, angle);
            }
            else
            {
                if (isFacingRight)
                {
                    gunArm.rotation = Quaternion.Euler(0, 0, 0);
                    gunArm.localScale = Vector3.one;
                }
                else
                {
                    gunArm.rotation = Quaternion.Euler(0, 0, -180);
                    gunArm.localScale = new Vector3(-1f, -1f, 1f);
                }
                
            }
        }
        Flip();
        //myRigidbody2D.velocity = moveInput * activeMoveSpeed * Time.fixedDeltaTime;
    }

    private void Flip()
    {
        if (closetEnemy != null)
        {
            if (closetEnemy.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
                gunArm.localScale = new Vector3(-1f, -1f, 1f);
                isFacingRight = false;
            }
            else
            {
                transform.localScale = Vector3.one;
                gunArm.localScale = Vector3.one;
                isFacingRight = true;
            }
        }
        else
        {
            if (dirX > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
                gunArm.localScale = Vector3.one;
                isFacingRight = true;
            }
            else if (dirX < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                gunArm.localScale = new Vector3(-1f, -1f, 1f);
                isFacingRight = false;
            }
           
        }

        
    }

    public Transform getClosetEnemy()
    {
        multiEnemy = GameObject.FindGameObjectsWithTag("Enemy");

        float closetDistance = Mathf.Infinity;
        Transform trans = null;

        foreach (GameObject enemy in multiEnemy)
        {
            float currentDistance;
            currentDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (currentDistance < closetDistance)
            {
                closetDistance = currentDistance;
                trans = enemy.transform;
            }
        }
        return trans;
    }
    public void GetDamage(int damage)
    {
        if (canGetDmg)
        {
            currentHp -= damage;
            timeBtwHurt = 1f;
            if(currentHp <= 0)
            {
                UIController.instance.deathScreen.SetActive(true);
                Time.timeScale = 0f;
            }
        }       
    }

    public void Dash()
    {
        if (canDash)
        {
            Vector3 dashPos = transform.position + moveInput * dashDistance;

            RaycastHit2D raycast = Physics2D.Raycast(transform.position, moveInput, dashDistance, layerMask);
            if(raycast.collider != null)
            {
                dashPos = raycast.point;
                Debug.Log(raycast);
            }

            rb.MovePosition(dashPos);
            dashDuration = dashTime;
        }
        
    }

    public void SwapWeap()
    {
        currentWeap = hand.GetComponentInChildren<RangeWeaponController>();
    }

    public void UpdateStats(UpdateChoice.UpdatePlayer upStats)
    {
        maxHp += upStats.upHp;
        currentHp += upStats.upHp;
        maxSpeed += upStats.upSpeed;
        currentSpeed += upStats.upSpeed;
    }

    public void UpdateCurrentWeap(UpdateChoice.UpdateWeap upWeap)
    {
        currentWeap.UpdateWeap(upWeap);
        
    }
}
