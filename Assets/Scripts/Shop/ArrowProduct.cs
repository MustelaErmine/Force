using RuStore.BillingClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowProduct : MonoBehaviour
{
    [SerializeField] Image check_true;
    [SerializeField] Button payButton, check_false;
    [SerializeField] int arrowNumber;
    public string productId;
    public bool paiyed = false;

    void Start()
    {
        ArrowShopContainer.instance.products.Add(this);
        //temporary
        SetPayed(true);
    }
    public void SetPayed(bool newPaied)
    {
        paiyed |= newPaied;

        check_true.gameObject.SetActive(false);
        check_false.gameObject.SetActive(false);
        if (payButton != null)
            payButton.gameObject.SetActive(false);

        if (Save.Instance.cosmeticArrow == arrowNumber)
            check_true.gameObject.SetActive(true);
        else if (paiyed)
            check_false.gameObject.SetActive(true);
        else
            payButton.gameObject.SetActive(true);            
    }
    public void SetPrice(string price)
    {
        payButton.GetComponentInChildren<Text>().text = price;
    }
    public void Uncheck()
    {
        check_true.gameObject.SetActive(false);
        if (paiyed)
            check_false.gameObject.SetActive(true);
        else
            payButton.gameObject.SetActive(true);
    }
    public void Check()
    {
        ArrowShopContainer.instance.UncheckAll();
        check_true.gameObject.SetActive(true);
        check_false.gameObject.SetActive(false);
        if (payButton != null)
            payButton.gameObject.SetActive(false);
        Save.Instance.cosmeticArrow = arrowNumber;
        Save.Keep();
    }
    public void Pay()
    {
        RuStoreBillingClient.Instance.PurchaseProduct(
            productId: productId,
            quantity: 1,
            developerPayload: "your payload",
            onFailure: (error) => {
                print(error);
            },
            onSuccess: (result) => {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Costumisation");
            });
    }
}
