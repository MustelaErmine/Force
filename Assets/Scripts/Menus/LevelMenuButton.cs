using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenuButton : MonoBehaviour
{
    [SerializeField]
    Image[] stars;
    string levelNum, levelName;
    TMPro.TMP_Text text;
    [SerializeField]
    string seasonPrefix;
    [SerializeField]
    Sprite filledStar;
    [SerializeField]
    GameObject backgroundMusic;

    Button button;

    void Start()
    {
        text = GetComponentInChildren<TMPro.TMP_Text>();
        button = GetComponentInChildren<Button>();
        levelNum = gameObject.name.Split('.').ToList().Last();
        levelName = $"{seasonPrefix}Level{levelNum}";
        text.text = levelNum;
        //print(gameObject.name.Split('.')[1]);

        int starsCount = 0;
        if (Save.Instance.stars.ContainsKey(levelName))
        {
            starsCount = Save.Instance.stars[levelName];
        }

        for (int i = 1; i <= 3; i++)
        {
            if (starsCount >= i)
                stars[i - 1].sprite = filledStar;
        }

        if (!LevelManager.seasonContainer.IsPreviousDone(levelName))
        {
            Color uninteractable = new Color(1, 1, 1, 0.7f);
            foreach (Image image in stars)
                image.color = uninteractable;
            button.interactable = false;
            text.color = uninteractable;
        }

    }
    public void Activate()
    {
        Instantiate(backgroundMusic);
        StartCoroutine(ActivateCorounite());
    }
    IEnumerator ActivateCorounite()
    {
        yield return new WaitForSeconds(0.01f);
        LevelManager.GoToLevel(levelName);
    }
}
