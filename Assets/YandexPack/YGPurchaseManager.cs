using UnityEngine;
using YG;

public class YGPurchaseManager : MonoBehaviour
{
    private void Awake()
    {
        //YG2.InitAuth();
    }
    private void Start()
    {
        // QUAN TRỌNG: Khôi phục các purchase chưa consume và PHÁT LẠI onPurchaseSuccess
       // YG2.ConsumePurchases(true);
    }
    private void OnEnable()
    {
        //YG2.onPurchaseSuccess += OnPurchaseSuccess;
    }


    private void OnDisable()
    {
       // YG2.onPurchaseSuccess -= OnPurchaseSuccess;
    }

    private void OnPurchaseSuccess(string id)
    {
        
    }
}