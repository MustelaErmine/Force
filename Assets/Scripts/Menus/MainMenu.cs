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
    [SerializeField] TMP_Dropdown langDropdown;
    [SerializeField] LocaledString boostLocaled;

    void Start()
    {
        Time.timeScale = 1f;
        if (textMeshStars != null)
            textMeshStars.text = $"Stars: {Save.Instance.earnedStars}";
        if (langDropdown != null)
        {
            langDropdown.value = Save.Instance.locale == LocaledString.Locale.ru_RU ? 0 : 1;
        }
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
                        Save.Keep();
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
    public void HandleLanguage()
    {
        switch (langDropdown.value)
        {
            case 0:
                Save.Instance.locale = LocaledString.Locale.ru_RU;
                break;
            case 1:
                Save.Instance.locale = LocaledString.Locale.en_US;
                break;
            default:
                break;
        }
        Save.Keep();
    }
}
