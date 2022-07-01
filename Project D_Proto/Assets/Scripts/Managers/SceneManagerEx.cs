using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class SceneManagerEx : MonoBehaviour
{
    public Define.Scene nextScene;


    public void LoadScene(Define.Scene type)
    {
        nextScene = type;
        SceneManager.LoadScene(GetSceneName(Define.Scene.LoadingScene));
    }
    
    public string GetSceneName(Define.Scene type)
    {
        string name = System.Enum.GetName(typeof(Define.Scene), type);
        return name;
    }

    public IEnumerator FadeInAnimation(Image image = null, TextMeshProUGUI text = null, float fadeSpeed = 0.7f)
    {
        if (image != null)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0.0f);
            while (true)
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, 0.2f + image.color.a + Time.deltaTime * fadeSpeed);
                yield return null;

                if(image.color.a >= 0.9)
                {
                    image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
                    yield break;
                }
            }
        }
        if (text != null)
        {
            text.color = new Color(1, 1, 1, 0.0f);
            while (text.color.r >= 1)
            {
                text.color = new Color(1, 1, 1, text.color.a + Time.deltaTime * fadeSpeed);
                yield return null;

                if (text.color.a >= 0.85)
                {
                    text.color = new Color(1, 1, 1, 1);                 
                    yield break;
                }
            }
        }
    }
    public IEnumerator FadeOutAnimation(Image image = null, TextMeshProUGUI text = null, float fadeSpeed = 1.0f)
    {
        if (image != null)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
            while (true)
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - Time.deltaTime * fadeSpeed);
                yield return null;

                if(image.color.a <= 0.15)
                {
                    image.color = new Color(image.color.r, image.color.g, image.color.b, 0);             
                    yield break;
                }
            }

        }
        if (text != null)
        {
            text.color = new Color(1, 1, 1, 1f);
            while (true)
            {
                text.color = new Color(1, 1, 1, text.color.a - Time.deltaTime * fadeSpeed);
                yield return null;
                
                if (text.color.a <= 0.15)
                {
                    text.color = new Color(1, 1, 1, 0);
                    yield break;
                }
            }
        }
    }
    public IEnumerator BlinkAnimation(Image image = null, TextMeshProUGUI text = null, float fadeSpeed = 1.0f)
    {
        if(image != null)
        {
            while (true)
            {
                if (image.color.a <= 0.15)
                {
                    while (true)
                    {
                        image.color = new Color(1, 1, 1, image.color.a + Time.deltaTime * fadeSpeed);
                        yield return null;
                        if (image.color.a >= 0.85)
                        {
                            image.color = new Color(1, 1, 1, 1);
                            break;
                        }
                    }
                }
                else if (image.color.a >= 0.85)
                {
                    while (true)
                    {
                        image.color = new Color(1, 1, 1, image.color.a - Time.deltaTime * fadeSpeed);
                        yield return null;
                        if (image.color.a <= 0.15)
                        {
                            image.color = new Color(1, 1, 1, 0);
                            break;
                        }
                    }
                }
            }
        }
        if (text != null)
        {
            while (true)
            {
                if (text.color.a <= 0.15)
                {
                    while (true)
                    {
                        text.color = new Color(1, 1, 1, text.color.a + Time.deltaTime * fadeSpeed);
                        yield return null;
                        if (text.color.a >= 0.85)
                        {
                            text.color = new Color(1, 1, 1, 1);
                            break;
                        }
                    }
                }
                else if (text.color.a >= 0.85)
                {
                    while (true)
                    {
                        text.color = new Color(1, 1, 1, text.color.a - Time.deltaTime * fadeSpeed);
                        yield return null;
                        if (text.color.a <= 0.15)
                        {
                            text.color = new Color(1, 1, 1, 0);
                            break;
                        }
                    }
                }
            }
        }

    }


}
