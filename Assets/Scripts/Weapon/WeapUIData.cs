using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeapUIData : MonoBehaviour
{
    [SerializeField] private Button buyBtn;
    [SerializeField] private Image weapIcon;
    [SerializeField] private Text weapName;
    [SerializeField] private Text weapAtk;
    [SerializeField] private Text weapRate;
    [SerializeField] private Text weapAmmo;
    [SerializeField] private Text weapPrice;
    [SerializeField] private bool isOwner;
    private float price;

    private void Start()
    {
        if (!isOwner)
        {
            buyBtn.onClick.AddListener(() => Buying());
        }
        else
        {
            buyBtn.onClick.AddListener(() => Equip());
        }
    }
    public void Show(Sprite icon, string name, int atk, float rate, int ammo, float price)
    {
        weapIcon.sprite = icon;
        weapName.text = name;
        weapAtk.text = "Atk: " + atk.ToString();
        float fr = 1 / rate;
        weapRate.text = "Rate: " + fr.ToString("F2");
        weapAmmo.text = "Ammo: " + ammo.ToString();
        weapPrice.text = "Buy\n" + price.ToString() +"g";
        this.price = price;
    }
    
    public void Buying()
    {
        if(GameManager.instance.playerGold < price && !isOwner)
        {
            StartScreenUI.instance.WatchAds();
        }
        else
        {
            GameManager.instance.playerGold -= (int) price;
            isOwner = true;
            buyBtn.onClick.RemoveAllListeners();
            buyBtn.onClick.AddListener(() => Equip());
            weapPrice.text = "Equip";
            buyBtn.gameObject.transform.GetChild(0).GetComponent<Outline>().effectColor = new Color(0, 64, 91, 255);
        }
    }

    public void Equip()
    {
        Debug.Log("Equip");
        GameObject.Find("Weapon Manager").GetComponent<WeaponManager>().Equip(weapName.text);
        weapPrice.text = "UnEquipped";
        buyBtn.onClick.RemoveAllListeners();
        buyBtn.onClick.AddListener(() => UnEquip());
    }

    public void UnEquip()
    {
        if (isOwner)
        {
            Debug.Log("UnEquip");
            weapPrice.text = "Equip";
            buyBtn.onClick.RemoveAllListeners();
            buyBtn.onClick.AddListener(() => Equip());
        }
    }
}
