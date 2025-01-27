//using RuStore.BillingClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1f;
        /*RuStoreBillingClient.Instance.GetPurchases(
                    onFailure: (error) =>
                    {
                    },
                    onSuccess: (response) =>
                    {
                        foreach (Purchase purchase in response)
                        {
                            if (purchase.productId == "ads-free-1")
                            {
                                Save.Instance.adfree = true;
                                Save.Keep();
                            }
                        }

                    });*/
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void GoToScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
