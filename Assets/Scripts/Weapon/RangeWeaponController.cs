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
    [SerializeField] public float reloadTime;

    [Header("Effect")]
    [SerializeField] private Transform dropBulletEff;
    [SerializeField] private GameObject fireEft;

    [SerializeField] private BulletController bulletData;
    [HideInInspector] public int currentBullet;
    [HideInInspector] public int magazine;
    [HideInInspector] public float reloadtime;
    

    private float timeBtwAtk;
    private bool canAttack = true;
    private bool isReload = false;

    private void Start()
    {
        timeBtwAtk = timeBtwAttack;
        currentBullet = maxBullet;
        magazine = 1; 
        //reloadtime = reloadTime;
    }

    private void Update()
    {
        if(magazine>=0|| gameObject.name.Equals("Base Gun"))
        {
            if (currentBullet > 0)
            {
                if (canAttack && !isReload)
                {
                    if (Input.GetKey(KeyCode.Space) || CrossPlatformInputManager.GetButton("Fire"))
                    {
                        //Instantiate(bullet, firePoint.position, firePoint.rotation);
                        //Instantiate(fireEft, dropBulletEff.position, dropBulletEff.rotation);
                        GameObject b = BulletPool.instance.bulletPool.GetObject(bullet.name);
                        b.transform.position = firePoint.position;
                        b.transform.rotation = firePoint.rotation;

                        GameObject ef = BulletPool.instance.bulletPool.GetObject(fireEft.name);
                        ef.transform.position = dropBulletEff.position;
                    
                        timeBtwAtk = timeBtwAttack;
                        currentBullet -= 1;
                    }
                }
            }
            else
            {
                reloadtime = reloadTime;
                currentBullet = maxBullet;
                magazine--;
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
        else if(magazine<0)
        {
            
            PlayerController.instance.SwapWeap(null);
            Destroy(this.gameObject);
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
                timeBtwAtk = timeBtwAtk - timeBtwAtk * upData.upFireRate;
                bulletData.Updamage(upData.upDamage);
            }
        }
        catch(Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}
