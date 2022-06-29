using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImgDestroy : MonoBehaviour
{
    [SerializeField] Image img;

    // Update is called once per frame
    void Update()
    {
        if (img.color.a==0.0f)
        {
            Destroy(img);
        }
    }
}
