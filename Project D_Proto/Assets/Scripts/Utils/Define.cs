using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define 
{
   public enum Scene
    {
        MainScene,
        Intro,
        LoadingScene,
        PlayScene1,
        PlayScene2
    }


    public static List<string> s_backgrounds = new List<string>
    {
        "거실", "경찰서(밖)", "경찰서(밖_밤)", "경찰서(안)", "경찰서(안_밤)",
        "공용욕실", "다용도실", "드레스룸", "서재(우)", "서재(좌)", "안방",
        "안방욕실", "주방_식당", "지훈의방(밤)", "지훈의방", "침실3"
    };

    public static List<string> s_tips = new List<string>
    {
        "Tip. 낮선 곳에 떨어졌으면 침착을 유지해야 합니다.",
        "Tip. 시체를 마주쳤으면 망설이지 말아야 합니다.",
        "Tip. 어떤 폭력은 윌스미스 해도 됩니다.",
        "테스트 4444444444444444444444444",
        "테스트 5555555555555555555555555"
    };


}
