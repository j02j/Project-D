using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tip : MonoBehaviour
{
    // Start is called before the first frame update

    private void Start()
    {
        Tips();
    }

    public void Tips()
    {
        List<string> stringfield = new List<string> { 
            "Tip. 낮선 곳에 떨어졌으면 침착을 유지해야 합니다.",
            "Tip. 시체를 마주쳤으면 망설이지 말아야 합니다.",
            "Tip. 어떤 폭력은 윌스미스 해도 됩니다." };

        int temp = Random.Range(0, 3);
    }
}
