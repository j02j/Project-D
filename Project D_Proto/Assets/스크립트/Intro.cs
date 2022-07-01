using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Intro : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI fiction;
    [SerializeField] TextMeshProUGUI click;
    [SerializeField] TextMeshProUGUI director;
    [SerializeField] TextMeshProUGUI art;
    [SerializeField] Image background;
    [SerializeField] Image backPanel;
    [SerializeField] Image block1;
    [SerializeField] Image block2;
    [SerializeField] Image block3;

    Sprite[] sprites;
    Image[] blocks;

    int _count = 0;
    float time = 0;

    void Start()
    {
        sprites = new Sprite[3];
        blocks = new Image[3] { block1, block2, block3 };
        
        LoadSprite();

        block1.gameObject.AddComponent<Button>();
        block1.gameObject.GetComponent<Button>().onClick.AddListener(Block1);
        block1.gameObject.GetComponent<Button>().transition = Selectable.Transition.None;

        block2.gameObject.AddComponent<Button>();
        block2.gameObject.GetComponent<Button>().onClick.AddListener(Block2);
        block2.gameObject.GetComponent<Button>().transition = Selectable.Transition.None;

        block3.gameObject.AddComponent<Button>();
        block3.gameObject.GetComponent<Button>().onClick.AddListener(Block3);
        block3.gameObject.GetComponent<Button>().transition = Selectable.Transition.None;

        background.gameObject.AddComponent<Button>();
        background.gameObject.GetComponent<Button>().onClick.AddListener(BackGround);
        background.gameObject.GetComponent<Button>().transition = Selectable.Transition.None;

        StartCoroutine(GameManager.Scene.FadeInAnimation(null, fiction));
        StartCoroutine(GameManager.Scene.BlinkAnimation(null, click));   
    }


    private void Update()
    {
        time += Time.deltaTime;
    }

    public void LoadSprite()
    {
        sprites[0] = Resources.Load<Sprite>("BackGround/지훈의방(밤)");
        sprites[1] = Resources.Load<Sprite>("BackGround/경찰서(밖_밤)");
        sprites[2] = Resources.Load<Sprite>("BackGround/경찰서(안_밤)");
    }

    public void Block1()
    {
        if (time <= 2) return;

        block1.gameObject.SetActive(false);
        _count++;
        ChangeImage();
        background.gameObject.SetActive(true);
        StartCoroutine(GameManager.Scene.FadeOutAnimation(backPanel));

        time = 0;
    }

    public void Block2()
    {
        if (time <= 2) return;

        block2.gameObject.SetActive(false);
        _count++;
        ChangeImage();
        background.gameObject.SetActive(true);
        StartCoroutine(GameManager.Scene.FadeOutAnimation(backPanel));
    
        time = 0;
    }

    public void Block3()
    {
        if (time <= 2) return;
        
        block3.gameObject.SetActive(false);
        _count++;
        ChangeImage();
        background.gameObject.SetActive(true);
        StartCoroutine(GameManager.Scene.FadeOutAnimation(backPanel));
    
        time = 0;
    }

    public void ChangeImage()
    {
        background.sprite = sprites[_count - 1];
    }

    public void BackGround()
    {
        if (time <= 2) return;
        
        background.gameObject.SetActive(false);
        
        if (_count == 1)
        {
            StartCoroutine(GameManager.Scene.FadeInAnimation(null, director));
            blocks[_count].gameObject.SetActive(true);
        }
        if (_count == 2)
        {
            StartCoroutine(GameManager.Scene.FadeInAnimation(null, art));
            blocks[_count].gameObject.SetActive(true);
        }
        if(_count == 3)
        {
            GameManager.Scene.LoadScene(Define.Scene.PlayScene1);
        }
    
        time = 0;
    }




}