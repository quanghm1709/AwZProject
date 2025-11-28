using UnityEngine;
using YG;

public class GoldPurchase : MonoBehaviour
{
    [SerializeField] string productId;

    public void BuyProduct()
    {
        YG2.BuyPayments(productId);
    }
}
