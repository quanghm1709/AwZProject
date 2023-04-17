using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private Item item;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (item.isCoin)
            {
                GameManager.instance.coin += item.coinAmount;
                gameObject.SetActive(false);
                //Destroy(gameObject);
            }
        }
    }
}
