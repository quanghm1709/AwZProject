using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private List<WeaponController> weapons;
    [SerializeField] private List<WeapUIData> weapUIs;
    [SerializeField] public GameObject DropGun; 

    [SerializeField] public static GameObject DropGunBase ; 


    private void Start()
    {
        DropGunBase = DropGun; 
        foreach (WeaponController weap in weapons)
        {
            weapUIs[weapons.IndexOf(weap)].Show(weap.weapUI, weap.weaponName, weap.damage, weap.timeBtwAttack, weap.maxBullet, weap.price);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void Equip(string name)
    {
        int pos = 0;
        foreach(WeaponController weap in weapons)
        {
            weapUIs[weapons.IndexOf(weap)].UnEquip();

            if (weap.weaponName.Equals(name))
            {
                GameManager.instance.weapon = weap;
                pos = weapons.IndexOf(weap);             
            }
        }
        //weapUIs[pos].Equip();
    }

    public WeaponController GetImage(string name)
    {
        WeaponController a = new WeaponController();
        foreach (WeaponController weap in weapons)
        {
            if (weap.weaponName.Equals(name))
            {
                a = weap; 
                return a;
            }
        }
        return a;
    }
}
