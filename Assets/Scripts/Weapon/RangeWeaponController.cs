using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class RangeWeaponController : WeaponController
{
    [SerializeField] public int atk;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float timeBtwAttack;
    [SerializeField] public int maxBullet;
    [SerializeField] public float reloadTime;

    [Header("Effect")]
    [SerializeField] private Transform dropBulletEff;
    [SerializeField] private GameObject fireEft;

    [SerializeField] private BulletController bulletData;
    [HideInInspector] public int currentBullet;
    [HideInInspector] public float reloadtime;
    private float timeBtwAtk;
    private bool canAttack = true;
    private bool isReload = false;

    private void Start()
    {
        timeBtwAtk = timeBtwAttack;
        currentBullet = maxBullet;
        //reloadtime = reloadTime;
    }

    private void Update()
    {
        if(currentBullet > 0)
        {
            if (canAttack && !isReload)
            {
                if (Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButtonDown("Fire"))
                {
                     Instantiate(bullet, firePoint.position, firePoint.rotation);
                     Instantiate(fireEft, dropBulletEff.position, dropBulletEff.rotation);
                    //GameObject b = BulletPool.instance.bulletPool.GetObject(bullet.name);
                    //b.transform.position = firePoint.position;
                    //b.transform.rotation = firePoint.rotation;

                    //GameObject ef = BulletPool.instance.bulletPool.GetObject(fireEft.name);
                   // ef.transform.position = dropBulletEff.position;
                    
                    timeBtwAtk = timeBtwAttack;
                    currentBullet -= 1;
                }
            }
        }
        else
        {
            reloadtime = reloadTime;
            currentBullet = maxBullet;
        }
        

        //Reload
        if (reloadtime > 0)
        {
            reloadtime -= Time.deltaTime;
            isReload = true;
        }
        else if (reloadtime <=0 )
        {
            
            isReload = false;
        }

        if (!isReload)
        {
            //Time btw attack
            if (timeBtwAtk > 0)//|| reloadtime > 0)
            {
                canAttack = false;
                timeBtwAtk -= Time.deltaTime;
            }
            else
            {
                canAttack = true;
            }
        }
          
    }

    public void UpdateWeap(UpdateChoice.UpdateWeap upData)
    {
        try
        {
            if (upData != null)
            {
                maxBullet += (int)(maxBullet * upData.upAmmo);
                reloadTime -= upData.upReload;
                timeBtwAttack = upData.upFireRate;
                bulletData.Updamage(upData.upDamage);
            }
        }
        catch(Exception e)
        {
            Debug.Log(e.Message);
        }
         
        

    }
}
