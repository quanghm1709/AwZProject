using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private List<WeaponController> weapons;
    [SerializeField] private List<WeapUIData> weapUIs;

    private void Start()
    {
        foreach(WeaponController weap in weapons)
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
}
