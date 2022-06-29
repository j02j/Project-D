
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FadeAnimation : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Image img;

    void Awake()
    {
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
        Image img = GetComponent<Image>();
        StartCoroutine(FadeTextToFullAlpha());
    }

    public IEnumerator FadeTextToFullAlpha()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / 1.0f));
            yield return null;
        }
        //StartCoroutine(FadeTextToZero());
    }

    public IEnumerator FadeTextToZero()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a);
        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / 1.0f));
            yield return null;
        }
     }

    public IEnumerator FadeImgToZero()  // 알파값 1에서 0으로 전환
    {
        Destroy(text);
        img.color = new Color(img.color.r, img.color.g, img.color.b, img.color.a);
        while (img.color.a > 0.0f)
        {
            img.color = new Color(img.color.r, img.color.g, img.color.b, img.color.a - (Time.deltaTime / 20.0f));
            yield return null;
        }
        Destroy(img);
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            StartCoroutine(FadeImgToZero());
            StartCoroutine(FadeTextToZero());        
        }
    }
}
