//using RuStore.BillingClient;
using PlayablesStudio.Plugins.YandexGamesSDK.Runtime;
using PlayablesStudio.Plugins.YandexGamesSDK.Runtime.Modules.Advertisement;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshStars;
    [SerializeField]
    private LocaledString boostLocaled;

    void Start()
    {
        Time.timeScale = 1f;
        if (textMeshStars != null)
            textMeshStars.text = $"Stars: {Save.Instance.earnedStars}";
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void GoToScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void RewardedBoostStars()
    {
        YandexGamesSDK.Instance.Advertisement.ShowRewardedAd((success, adResponse, error) =>
        {
            if (success)
            {
                switch (adResponse)
                {
                    case YGAdResponse.AdOpened:
                        Debug.Log("Rewarded ad opened.");
                        break;
                    case YGAdResponse.AdGranted:
                        Debug.Log("Reward granted for watching ad.");
                        Save.Instance.starsBoostTime = DateTime.Now;
                        NotifyManager.NotifyLocaled(boostLocaled);
                        break;
                    case YGAdResponse.AdClosed:
                        Debug.Log("Rewarded ad closed.");
                        break;
                    default:
                        Debug.Log($"Unknown ad response: {adResponse}");
                        break;
                }
            }
            else
            {
                Debug.LogError($"Failed to show rewarded ad: {error}");
            }
        });
    }
}
