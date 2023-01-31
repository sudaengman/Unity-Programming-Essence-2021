using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    /*코드의 비쥬얼화 : 이 중에 public speed만 유니티 창에 보여진다.*/
    /*유니티에서 모든 좌표계는 실수(float)을 쓴다.*/
    public float speed = 5.0f;
    protected float hou = 3.0f;
    private float hey = 2.0f;

    public float angle = 90;

    public float maxCount = 50;
    int count = 0;

    public float maxY = 4;
    public

    // Start is called before the first frame update
    void Start()
    {
        int count = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        /*this 는 유니티에서 class뿐만 아니라 이 move 클래스를 포함된 GameObject를 포함함.*/
        /*포지션 정보를 바꾸기 위해선 translate()를 써야 합니다*/
        /*스크립트는 게임 오브젝트에게 언제 무엇을 할 것인지 알려주는 역할을 한다.*/
        //this.transform.Translate(speed / 50f, 0, 0); // 초당 x 축으로 0.1만큼 이동하는 것을 60회 반복한다.

    }
    // FixedUpdate : 초당 50번을 보장해준다? 뭔가 복잡한 동작을 구현할 때 씹히는 걸 방지하기위해 여기에 넣어둔다
    private void FixedUpdate()
    {
        //this.transform.Translate(speed / 50f, speed / 50f, 0); // 초당 x 축으로 0.1만큼 이동하는 것을 60회 반복한다.
        //this.transform.Rotate(0,0,angle/50);

        ///*1초에 한 번씩 90도씩 꺾는 코드*/
        //count = count + 1;

        //if (count >= maxCount )
        //{
        //    this.transform.Rotate(0,0,angle);
        //    count = 0;
        //}

        this.transform.Translate(0,speed/ 50f,0);
        if ((speed / 50f) >= 4)
        {
            transform.Translate(speed/50f,0,0);

        }
    }
}
