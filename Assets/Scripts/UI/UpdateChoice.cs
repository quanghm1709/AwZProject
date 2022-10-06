using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateChoice : MonoBehaviour
{
    public static UpdateChoice instance;

    [System.Serializable]
    public class UpdatePlayer
    {
        [SerializeField] public int upHp;
        [SerializeField] public float upSpeed;
    }

    [System.Serializable]
    public class UpdateWeap
    {
        [SerializeField] public int upDamage;
        [SerializeField] public float upFireRate;
        [SerializeField] public float upAmmo;
        [SerializeField] public float upReload;
    }

    [SerializeField] private UpdatePlayer[] upPlayer;
    [SerializeField] private UpdateWeap[] upWeap;
    [SerializeField] public RangeWeaponController[] weapToSwap;
    private void Awake()
    {
        instance = this;
    }

    public void UpdatePlayerStats(UpdateCard card)
    {
        if(GameManager.instance.coin < card.cardCost)
        {
            return;
        }
        else
        {
            PlayerController.instance.UpdateStats(upPlayer[card.cardID]);
            UIController.instance.updateScreen.SetActive(false);
            GameManager.instance.coin -= card.cardCost;
        }

    }

    public void UpdateWeapStats(UpdateCard card)
    {

        if (GameManager.instance.coin < card.cardCost)
        {
            return;
        }
        else
        {
            PlayerController.instance.UpdateCurrentWeap(upWeap[card.cardID]);
            UIController.instance.updateScreen.SetActive(false);
            GameManager.instance.coin -= card.cardCost;
        }
        
    }

    public void SwapWeap(UpdateCard card)
    {

        if (GameManager.instance.coin < card.cardCost)
        {
            return;
        }
        else
        {
            GameManager.instance.coin -= card.cardCost;
            //Delete curretn weap
            foreach (Transform child in PlayerController.instance.hand)
            {
                Destroy(child.gameObject);
            }

            //Instantiate new weap
            RangeWeaponController weap = Instantiate(weapToSwap[card.cardID]);
            weap.transform.parent = PlayerController.instance.hand;
            weap.transform.position = PlayerController.instance.hand.position;
            weap.transform.localRotation = Quaternion.Euler(Vector3.zero);
            weap.transform.localScale = Vector3.one;

            PlayerController.instance.currentWeap = weap;

            foreach (Transform child in UIController.instance.cardDisplay.transform)
            {
                Destroy(child.gameObject);
            }
            UIController.instance.updateScreen.SetActive(false);
        }
        
    }
}
