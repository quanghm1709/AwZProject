using UnityEngine;
using YG;

public class YGPurchaseManager : MonoBehaviour
{
    private void Awake()
    {
        YG2.InitAuth();
    }
    private void Start()
    {
        // QUAN TRỌNG: Khôi phục các purchase chưa consume và PHÁT LẠI onPurchaseSuccess
        YG2.ConsumePurchases(true);
    }
    private void OnEnable()
    {
        YG2.onPurchaseSuccess += OnPurchaseSuccess;
    }


    private void OnDisable()
    {
        YG2.onPurchaseSuccess -= OnPurchaseSuccess;
    }

    private void OnPurchaseSuccess(string id)
    {
        switch (id)
        {
            case "gungold_100":
                DataManager.Instance.Gold += 100;
                break;
            case "gungold_250":
                DataManager.Instance.Gold += 250;

                break;
            case "gungold_2000":
                DataManager.Instance.Gold += 2000;
                break;
        }
        GameObject.FindFirstObjectByType<StartScreenUI>().UpdateGoldUI();
        YG2.ConsumePurchaseByID(id, false);
    }
}