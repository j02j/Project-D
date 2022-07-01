using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class Loading : MonoBehaviour
{
    [SerializeField] Image progressBar;
    [SerializeField] TextMeshProUGUI loadpercentage;

    [SerializeField] Image background;
    [SerializeField] TextMeshProUGUI tiptext;

    private void Start()
    {
        RandomLoadingImage();
        RandomLoadingTips();

        StartCoroutine(LoadScene());
    }


    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync(GameManager.Scene.GetSceneName(GameManager.Scene.nextScene));
        op.allowSceneActivation = false;
        float timer = 0.0f;

        
        while (!op.isDone)
        {
            yield return null;
            timer += Time.deltaTime;
            if (op.progress < 0.9f)
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer);
                if (progressBar.fillAmount >= op.progress)
                {
                    timer = 0f;
                }
            }
            else
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);
                float temp = progressBar.fillAmount;
                float percentage = (Mathf.Lerp(temp, 100, progressBar.fillAmount));
                loadpercentage.text = (Mathf.RoundToInt(percentage)).ToString() + "%";
                if (progressBar.fillAmount >= 1.0f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }

        }
    }

    void RandomLoadingImage()
    {
        int randNum = UnityEngine.Random.Range(0, Define.s_backgrounds.Count);
        background.sprite = Resources.Load<Sprite>($"BackGround/{Define.s_backgrounds[randNum]}");
    }

    void RandomLoadingTips()
    {
        while (true)
        {
            int randNum = UnityEngine.Random.Range(0, Define.s_tips.Count);
            tiptext.text = Define.s_tips[randNum];
            break;
        }
    }
}