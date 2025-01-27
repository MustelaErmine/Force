//using RuStore.BillingClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdFreeHandler : MonoBehaviour
{
    [SerializeField] Image checkmark;
    [SerializeField] Button button;

    void Start()
    {
        button.gameObject.SetActive(!Save.Instance.adfree);
        checkmark.gameObject.SetActive(Save.Instance.adfree);
    }

    public void Pay()
    {
        /*RuStoreBillingClient.Instance.PurchaseProduct(
            productId: "ads-free-1",
            quantity: 1,
            developerPayload: "your payload",
            onFailure: (error) =>
            {
                print(error);
            },
            onSuccess: (result) =>
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Costumisation");
            });*/
    }
}
