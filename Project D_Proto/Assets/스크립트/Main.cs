using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    [SerializeField] Button PlayBtn;
    public void OnClickScene()
    {
        Loading.LoadScene("Intro");
    }
}
