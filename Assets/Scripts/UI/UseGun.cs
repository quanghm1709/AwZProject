using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UseGun : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI gun_avaiable;
    string gun_name;
    private void Start()
    {
        gun_name = this.gameObject.name;
    }

    private void Update()
    {
        gun_avaiable.text = GameManager.instance.magazine_stored[gun_name].ToString();
    }
    public void Use_Gun()
    {
        
        if (GameManager.instance.magazine_stored[gun_name] > 0)
        {
            PlayerController.instance.SwapWeap(null);
            GameObject.Find("Weapon Manager").GetComponent<WeaponManager>().Equip(gun_name);
            PlayerController.instance.SwapWeap(GameManager.instance.weapon);
            GameManager.instance.magazine_stored[gun_name]--;
            
        }
    }

}
