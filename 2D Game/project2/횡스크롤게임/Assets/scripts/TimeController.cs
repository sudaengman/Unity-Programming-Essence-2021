using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TimeController : MonoBehaviour
{
    public bool isCountDown = true;
    public float gameTime = 0f;
    public bool isTimeOver = false; // true�� ��� Ÿ�̸� ����
    public float displayTime = 0f; // ǥ�� �ð�

    float curTime = 0f; //���� �ð�

    // Start is called before the first frame update
    void Start()
    {
        if (isCountDown)
        {
            displayTime = gameTime;
        }
    }

    // Update is called once per frame
    void Update() //�ʴ� ����� 60~80ȸ ������.
    {
        if (isTimeOver == false)
        {
            curTime += Time.deltaTime; // ���������ӿ��� ������������ ����ð�

            /*Ÿ�̸Ӱ� �� �۵��ϴ��� �����ϱ�*/
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
