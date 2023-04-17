using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeAdsReward : RewardedAdsButton
{
    [SerializeField] private int price;
    private void Start()
    {
        LoadAd();
    }

    public override void GrantReward()
    {
        GameManager.instance.playerGold += price;
        StartCoroutine(WaitForNextAds());
    }

    

    private IEnumerator WaitForNextAds()
    {
        yield return new WaitForSeconds(5f);
        LoadAd();
    }
}
