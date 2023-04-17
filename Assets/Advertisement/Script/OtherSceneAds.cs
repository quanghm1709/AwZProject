using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class OtherSceneAds : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] protected InterstitialAd interstitialAd;
    [SerializeField] protected List<RewardedAdsButton> rewardedAdsButtons;
    [SerializeField] protected List<BannerAd> bannerAds;

    public void OnInitializationComplete()
    {
        throw new System.NotImplementedException();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        throw new System.NotImplementedException();
    }

    private void Start()
    {
        if (Advertisement.isInitialized)
        {
            //Load ads
            interstitialAd.LoadAd();
            foreach (RewardedAdsButton btn in rewardedAdsButtons)
            {
                btn.LoadAd();
            }
            foreach (BannerAd bannerAd in bannerAds)
            {
                bannerAd.LoadBanner();
            }
        }

    }
}
