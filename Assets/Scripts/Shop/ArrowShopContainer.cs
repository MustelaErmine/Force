using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using RuStore.BillingClient;

public class ArrowShopContainer : MonoBehaviour
{
    public static ArrowShopContainer instance;
    public List<ArrowProduct> products;

    void Awake()
    {
        instance = this;
        /*RuStoreBillingClient.Instance.CheckPurchasesAvailability(
            onFailure: (error) =>
            {
                print(error);
                AllPayed();
            },
            onSuccess: (response) =>
            {
                if (response.isAvailable)
                {
                    print("purchases avialible");
                    OnPurchasesAvialible();
               }
               else
                {
                    AllPayed();
                }
            });*/
    }

    public void UncheckAll()
    {
        foreach (ArrowProduct product in products)
            product.Uncheck();
    }

    public void OnPurchasesAvialible()
    {
        /*RuStoreBillingClient.Instance.GetProducts(new string[2] { "ads-free-1", "boots_v1" },
            onFailure: (error) => {
                AllPayed();
            },
            onSuccess: (response) => {
                foreach(ArrowProduct product in products)
                {
                    foreach(Product productData in response)
                    {
                        if (product.productId == productData.productId)
                        {
                            product.SetPrice(productData.priceLabel);
                        }
                    }
                }
                RuStoreBillingClient.Instance.GetPurchases(
                    onFailure: (error) => {
                        AllPayed();
                    },
                    onSuccess: (response) => {
                        foreach (ArrowProduct product in products)
                        {
                            bool payed = false;
                            foreach (Purchase purchase in response)
                            {
                                if (purchase.productId == "ads-free-1")
                                {
                                    Save.Instance.adfree = true;
                                    Save.Keep();
                                }
                                if (product.productId == purchase.productId)
                                {
                                    if (purchase.purchaseState == Purchase.PurchaseState.CONFIRMED)
                                        payed = true;
                                }
                            }
                            product.SetPayed(payed);
                        }
                    });
            });*/
    }
    public void AllPayed()
    {
        foreach (ArrowProduct product in products)
            product.SetPayed(true);
    }
}
