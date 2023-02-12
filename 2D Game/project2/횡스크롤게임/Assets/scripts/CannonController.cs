using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{

    public GameObject objPrefab;
    public float delayTime = 3.0f;
    public float fireSpeedX = -4.0f;
    public float fireSpeedY = 0.0f;
    public float length = 8.0f;

    GameObject player;  //포탄을 맞을 대상
    GameObject GateObj; //발사체가 나갈 위치
    float passedTimes = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        /*자식으로 된 게임오브젝트를 찾을 때 transform.find 해주면 됨*/
        Transform tr = transform.Find("Gate");
        GateObj = tr.gameObject;

        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        passedTimes += Time.deltaTime;
        if (CheckLenghth(player.transform.position))
        {
            if (passedTimes > delayTime)
            {
                passedTimes = 0;

                Vector3 pos = new Vector3(GateObj.transform.position.x,
                                            GateObj.transform.position.y,
                                            GateObj.transform.position.z);
                /*pos 위치에서 objprefab을 만들겠다.*/
                GameObject objBullet = Instantiate(objPrefab, pos, Quaternion.identity);

                Rigidbody2D rbody = objBullet.GetComponent<Rigidbody2D>();
                Vector2 v = new Vector2(fireSpeedX, fireSpeedY);
                
                rbody.AddForce(v, ForceMode2D.Impulse);
            }
        }
    }

    /*사정거리 범위 안에 들었을 때*/
    bool CheckLenghth(Vector2 targetPos)
    {
        bool ret = false;

        /*타겟포스 : 플레이어와 대포 사이의 거리값을 변수 d에 넣겠다.*/
        float d = Vector2.Distance(transform.position, targetPos);
        if (length >= d) // 거리값이 length(8) 이하라면,
        {
            ret = true;
        }
        return ret;
    }
}
