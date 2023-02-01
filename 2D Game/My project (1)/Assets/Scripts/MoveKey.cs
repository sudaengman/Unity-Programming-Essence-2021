using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveKey : MonoBehaviour
{
    Rigidbody2D rigid2D = new Rigidbody2D();
    bool flipflag;
    float vx = 0;
    float vy = 0;
    // Start is called before the first frame update
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        rigid2D.gravityScale = 0;
        rigid2D.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        /* 키 입력을 하지 않을 때의 속도 */
        vx = 0;
        vy = 0;
        /* 이벤트 : 감지판단 */
        if (Input.GetKey(KeyCode.RightArrow) /* bool 값을 반환한다 ; = Input.GetKey("right"); */)
        {
            flipflag = false;
            vx = 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            flipflag = true;
            vx = -1;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            vy = 1;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            vy = -1;
        }
    }
    int count = 0;
    private void FixedUpdate()
    {
        /* 물리엔진에서 밀어주는 속도 */
        //if (count == 0)
        //{
        //    rigid2D.velocity = new Vector2(5,0);
        //}
        //if (count == 50)
        //{
        //    rigid2D.velocity = new Vector2(0,0);
        //}
        //count = count + 1;

        this.transform.Translate(vx / 50, vy / 50, 0); // 텔레포트
        this.GetComponent<SpriteRenderer>().flipX = flipflag;

        //isTrigger 체크하면 
    }
}
