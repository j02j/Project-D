using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{

    public void OnClickScene()
    {
        GameManager.Scene.LoadScene(Define.Scene.Intro);
    }
}
