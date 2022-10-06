using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCard : MonoBehaviour
{
    [Header("Card Data")]
    [SerializeField] public int cardID;
    [SerializeField] public string cardName;
    [SerializeField] public string description;
    [SerializeField] public int cardCost;
    [SerializeField] public bool isUpPlayer;
    [SerializeField] public bool isUpWeap;
    [SerializeField] public bool isSwapWeap;

    [Header("Card UI")]
    [SerializeField] private Text cardNameUI;
    [SerializeField] private Text CardDescriptionUI;

    [SerializeField] private Button cardBtn;

    private void Start()
    {
        cardNameUI.text = cardName;
        CardDescriptionUI.text = description;       
    }

    private void Update()
    {

    }


    /*[Header("Up Player")]
    [SerializeField] private int upHp;
    [SerializeField] private float upSpd;

    [Header("For Weap")]
    [SerializeField] private int upDmg;
    [SerializeField] private int upAmmo;
    [SerializeField] private float upFireRate;
    [SerializeField] private float upRload;*/
}
