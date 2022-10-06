using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] public bool isCoin;
    [SerializeField] public int coinAmount;

    [System.Serializable]
    public class Coin
    {
        [SerializeField] public int value;
    }

}
