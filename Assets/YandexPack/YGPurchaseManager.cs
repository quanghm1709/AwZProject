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
        //YG2.ConsumePurchases(true);
    }
    private void OnEnable()
    {
        //YG2.onPurchaseSuccess += OnPurchaseSuccess;
    }


    private void OnDisable()
    {
        //YG2.onPurchaseSuccess -= OnPurchaseSuccess;
    }

    private void OnPurchaseSuccess(string id)
    {
        //switch (id)
        //{
        //    case "apple_50":
        //        DataManager.Instance.Fruits += 50;
        //        Apple.Instance.UpdateApple();
        //        break;       
        //    case "apple_100":
        //        DataManager.Instance.Fruits += 100;
        //        Apple.Instance.UpdateApple();

        //        break;      
        //    case "apple_500":
        //        DataManager.Instance.Fruits += 500;
        //        Apple.Instance.UpdateApple();
        //        break;     
        //}
        //YG2.ConsumePurchaseByID(id, false);
    }
}