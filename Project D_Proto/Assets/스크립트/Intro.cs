using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI text1;
    [SerializeField] TextMeshProUGUI text2;
    [SerializeField] TextMeshProUGUI text3;
    [SerializeField] TextMeshProUGUI text4;
    [SerializeField] TextMeshProUGUI text5;
    [SerializeField] Image img1;
    [SerializeField] Image img2;
    [SerializeField] Image img3;
    [SerializeField] Image img4;
    [SerializeField] Image img5;
    [SerializeField] Image img6;

    void Awake()
    {
        Button PlayBtn = GetComponent<Button>();
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
        Image img = GetComponent<Image>();

        StartCoroutine(FadeTextToFullAlpha(text1, 1.0f));
        StartCoroutine(FadeTextToFullAlphaBlink(text2, 0.8f));
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void OnClick1()
    {
        GameBackgroundFadeOut(img1, text1, text2);
    }
    public void OnClick2()
    {
        StartCoroutine(FadeImgToZero(img2, 1.0f));
        StartCoroutine(FadeTextToFullAlpha(text3, 1.0f));
    }
    public void OnClick3()
    {
        GameBackgroundFadeOut(img3, text3);
    }
    public void OnClick4()
    {
        StartCoroutine(FadeImgToZero(img4, 1.0f));
        StartCoroutine(FadeTextToFullAlpha(text4, 1.0f));
        StartCoroutine(FadeTextToFullAlpha(text5, 1.0f));
    }
    public void OnClick5()
    {
        GameBackgroundFadeOut(img5, text4);
    }
    public void OnClick6()
    {
        StartCoroutine(FadeImgToZero(img6, 1.0f));
        GameManager.Scene.LoadScene(Define.Scene.PlayScene1);
        //Loading.LoadScene("Play Scene1");

    }

    public void GameBackgroundFadeOut(Image img, TextMeshProUGUI text) //뒷배경 서서히 없어지는 애니메이션 후 오브젝트 파괴
    {
        StopAllCoroutines();
        StartCoroutine(FadeImgToZero(img, 2.0f));
        StartCoroutine(FadeTextToZeroDestroy(text, 2.0f));
    }
    public void GameBackgroundFadeOut(Image img, TextMeshProUGUI text1, TextMeshProUGUI text2)
    {
        StopAllCoroutines();
        StartCoroutine(FadeImgToZero(img, 2.0f));
        StartCoroutine(FadeTextToZeroDestroy(text1, 2.0f));
        StartCoroutine(FadeTextToZeroDestroy(text2, 2.0f));

    }

    public IEnumerator BlinkTextAnim(TextMeshProUGUI text, float time) //깜빡이는 클릭유도 애니메이션
    {
        yield return null;
    }

    public IEnumerator FadeTextToFullAlpha(TextMeshProUGUI text, float time) // 투명도 0 에서 1로 만드는 함수 (텍스트)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / time));
            yield return null;
        }
    }

    public IEnumerator FadeTextToFullAlphaBlink(TextMeshProUGUI text, float time) // 투명도 0 에서 1로 만드는 함수 (텍스트)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / time));
            yield return null;
        }
        StartCoroutine(FadeTextToZeroBlink(text, time));
    }

    public IEnumerator FadeTextToZero(TextMeshProUGUI text, float time) // 투명도 1 에서 0으로 만드는 함수 (텍스트)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a);
        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / time));
            yield return null;
        }
    }

    public IEnumerator FadeTextToZeroDestroy(TextMeshProUGUI text, float time) // 투명도 1 에서 0으로 만들고 파괴하는 함수 (텍스트)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a);
        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / time));
            yield return null;
        }
        Destroy(text);
    }

    public IEnumerator FadeTextToZeroBlink(TextMeshProUGUI text, float time) // 투명도 1 에서 0으로 만드는 함수 (텍스트)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a);
        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / time));
            yield return null;
        }
        StartCoroutine(FadeTextToFullAlphaBlink(text, time));
    }

    public IEnumerator FadeImgToZero(Image img, float time) // 투명도 1 에서 0으로 만드는 함수 (이미지)
    {
        img.color = new Color(img.color.r, img.color.g, img.color.b, img.color.a);
        while (img.color.a > 0.0f)
        {
            img.color = new Color(img.color.r, img.color.g, img.color.b, img.color.a - (Time.deltaTime / time));
            yield return null;
        }
        Destroy(img);
    }

    public IEnumerator FadeImgToFullAlpha(Image img, float time) // 투명도 0 에서 1로 만드는 함수 (이미지)
    {
        img.color = new Color(img.color.r, img.color.g, img.color.b, img.color.a);
        while (text1.color.a < 1.0f)
        {
            img.color = new Color(img.color.r, img.color.g, img.color.b, img.color.a - (Time.deltaTime / time));
            yield return null;
        }
    }

}