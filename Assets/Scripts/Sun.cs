/*
참고
https://parksh3641.tistory.com/entry/%EC%9C%A0%EB%8B%88%ED%8B%B0-C-%ED%83%9C%EC%96%91-%EC%9B%80%EC%A7%81%EC%9E%84-%EB%B0%A4%EA%B3%BC-%EB%82%AE-%EC%8B%9C%EA%B0%84-%ED%9D%90%EB%A6%84-%EA%B0%84%EB%8B%A8-%EA%B5%AC%ED%98%84
*/

using UnityEngine;

public class Sun : MonoBehaviour
{
    public Light sun;

    // 낮, 밤 Skybox
    public Material daySkybox;
    public Material nightSkybox;

    public float dayDur;// 하루의 시간을 초 단위로
    private float curTime;// 현재 시간
    private float dayRatio;// 낮과 밤의 비율

    void Start()
    {
        curTime = 0f;
        dayDur = 24f;// 하루를 240초로
        UpdateSkyboxAndLighting();
    }

    void Update()
    {
        UpdateTime();
    }

    void UpdateTime()
    {
        curTime += Time.deltaTime;// 시간 업데이트
        dayRatio = curTime / dayDur;// 낮과 밤의 비율 계산

        // 하루가 끝나면 시간 초기화
        if (curTime > dayDur)
        {
            curTime = 0f;
        }

        UpdateSunPosition();
        UpdateSkyboxAndLighting();
    }

    void UpdateSunPosition()
    {
        float sunAngle = dayRatio * 360f;// 태양의 각도 계산

        sun.transform.rotation = Quaternion.Euler(sunAngle - 90f, 170f, 0f);// 태양 위치 업데이트
    }

    void UpdateSkyboxAndLighting()
    {
        // 낮일 때 Skybox와 조명 설정
        if (dayRatio < 0.5f)
        {
            //RenderSettings.skybox = daySkybox;
            sun.intensity = Mathf.Lerp(0.1f, 1f, dayRatio * 2);// 아침 -> 낮
            sun.color = Color.Lerp(Color.red, Color.white, dayRatio * 2);// 일출 색 변화
        }
        else
        {
            //RenderSettings.skybox = nightSkybox;
            sun.intensity = Mathf.Lerp(1f, 0.1f, (dayRatio - 0.5f) * 2);// 낮 -> 저녁
            sun.color = Color.Lerp(Color.white, Color.blue, (dayRatio - 0.5f) * 2);// 일몰 색 변화
        }

        DynamicGI.UpdateEnvironment();// Skybox 변경을 Unity에 알림
    }
}
