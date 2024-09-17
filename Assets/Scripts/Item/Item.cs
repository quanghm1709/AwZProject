using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] public string itemName;
    [SerializeField] public bool isCoin;
    [SerializeField] public bool isGun;
    [SerializeField] public int coinAmount;

    [System.Serializable]
    public class Coin
    {
        [SerializeField] public int value;
    }

}
