using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NextClickAnima : FadeAnimation
{
    [SerializeField] TextMeshProUGUI text1;
    [SerializeField] TextMeshProUGUI text2;
    [SerializeField] Image img2;

    void Awake()
    {
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
        Image img = GetComponent<Image>();
        StartCoroutine(FadeTextToFullAlpha(text1));
    }

    public virtual new IEnumerator FadeTextToFullAlpha(TextMeshProUGUI text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a);
        while (text1.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text1.color.g, text.color.b, text.color.a + (Time.deltaTime / 0.8f));
            yield return null;
        }
        StartCoroutine(FadeTextToZero(text));
    }

    public virtual new IEnumerator FadeTextToZero(TextMeshProUGUI text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a);
        while (text1.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / 0.8f));
            yield return null;
        }
        StartCoroutine(FadeTextToFullAlpha(text));
    }
    public void OnClicktext2()
    {
        StartCoroutine(FadeTextToZero(text2));
        StartCoroutine(FadeImgToZero(img2));
    }

    public IEnumerator FadeImgToZero(Image img)  // 알파값 1에서 0으로 전환
    {
        Destroy(text2);
        img.color = new Color(img.color.r, img.color.g, img.color.b, img.color.a);
        while (img.color.a > 0.0f)
        {
            img.color = new Color(img.color.r, img.color.g, img.color.b, img.color.a - (Time.deltaTime / 20.0f));
            yield return null;
        }
        Destroy(img);
    }
}
