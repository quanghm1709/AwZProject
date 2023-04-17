using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsManagerExample : AdsInitializer
{
    float timeToTurnOnAds = 10f;

    private void Start()
    {
        rewardedAdsButtons[0].enabled = false;
    }

    private void Update()
    {

    }
}
