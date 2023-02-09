using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TimeController : MonoBehaviour
{
    public bool isCountDown = true;
    public float gameTime = 0f;
    public bool isTimeOver = false; // true일 경우 타이머 정지
    public float displayTime = 0f; // 표시 시간

    float curTime = 0f; //현재 시간

    // Start is called before the first frame update
    void Start()
    {
        if (isCountDown)
        {
            displayTime = gameTime;
        }
    }

    // Update is called once per frame
    void Update() //초당 장면이 60~80회 찍힌다.
    {
        if (isTimeOver == false)
        {
            curTime += Time.deltaTime; // 이전프레임에서 다음프레임의 경과시간

            /*타이머가 잘 작동하는지 검증하기*/
            Debug.Log("CURTIME: " + curTime);
            if (isCountDown)
            {
                displayTime = gameTime - curTime;
                if (displayTime <= 0.0f)
                {
                    displayTime = 0.0f;
                    isTimeOver = true;
                }
            }
            else
            { 
                displayTime= curTime;
                if (displayTime >= gameTime)
                {
                    displayTime = gameTime;
                    isTimeOver= true;
                }
            }
            Debug.Log("TIMES:" + curTime);
        }
    }
}
