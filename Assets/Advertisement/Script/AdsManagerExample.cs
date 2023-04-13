using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsManagerExample : AdsInitializer
{
    float timeToTurnOnAds = 10f;

    private void Update()
    {
        //Test Interstital Ads
        if (timeToTurnOnAds > 0)
        {
            timeToTurnOnAds -= Time.deltaTime;
        }
        else
        {
            interstitialAd.ShowAd();
            timeToTurnOnAds = 10f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            bannerAds[0].DisableBanner();
        }
    }
}
