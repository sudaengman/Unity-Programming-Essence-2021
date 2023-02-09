using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    /*카메라가 왼쪽 오른쪽 스크롤 제한*/
    public float leftLimit = 0.0f;
    public float rightLimit = 0.0f;
    public float topLimit = 0.0f;
    public float bottomLimit = 0.0f;

    public GameObject subBackScreen;

    public bool isForceScrollx = false; // x축 강제 스크롤 플래그
    public float forceScrollSpeedX = 0.5f;  // 1초간 움직일 x의 거리
    public bool isForceScrollY = false; //y축 강제 스크롤 플래그
    public float forceScrollSpeedY = 0.5f; // 1초간 움직일 y의 거리

    


    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        
        /*player가 메모리에 잘 할당되었는지 검수코드*/
        if (player == null)
        {
            Debug.LogError("Player 게임오브젝트를 찾을 수 없음.");
            return;
        }
        
        float x = player.transform.position.x;
        float y = player.transform.position.y;
        float z = this.transform.position.z;

        if (isForceScrollx)
        {
            /*Time.deltaTime모든 컴퓨터에 초당 50초를 보장해줌*/
            x = transform.position.x + (forceScrollSpeedX * Time.deltaTime);
        }

        if (x < leftLimit)
        {
            x = leftLimit;
        }
        else if (x > rightLimit) 
        {
            x = rightLimit;
        }

        if (isForceScrollY)
        {
            y = transform.position.y + (forceScrollSpeedY * Time.deltaTime);
        }
        if (y < bottomLimit)
        {
            y = bottomLimit;
        }
        else if (y > topLimit)
        {
            y = topLimit;
        }

        Vector3 v3 = new Vector3(x, y, z);
        transform.position = v3;


        /*sub 배경화면의 이동속도를 다르게 해주기*/
        if (subBackScreen != null)
        { 
            y = subBackScreen.transform.position.y;
            z = subBackScreen.transform.position.z;

            Vector3 vSub = new Vector3(x / 2.0f, y, z);
            subBackScreen.transform.position = vSub;
        }

    }
}
