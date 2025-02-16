using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{

    public float moveX = 0.0f;          // x의 이동거리
    public float moveY = 0.0f;          // y의 이동거리
    public float times = 0.0f;
    public float weight = 0.0f;         // 정지 시간
    public bool isMoveWhenOn = false;   //

    public bool isCanMove = true;

    float perDx;                        // 1 프레임당 x 이동 값
    float perDy;                        // 1 프레임당 y 이동 값
    Vector3 defPos;                     // 초기 위치
    bool isReverse = false;             //

    // Start is called before the first frame update
    void Start()
    {
        defPos = this.transform.position;
        /* 1프레임에 걸리는 시간 == 이동시간 */
        float timeStep = Time.fixedDeltaTime;
        /* 1프레임의 x 이동 값*/
        perDx = moveX / (1.0f / timeStep * times);

        perDy = moveY / (1.0f / timeStep * times);

        if (isMoveWhenOn)
        {
            isCanMove = false;
        }
    }

    /*무빙 오브젝트의 작동코드*/
    private void FixedUpdate()
    {
        if (isCanMove) 
        {
            float x = transform.position.x;
            float y = transform.position.y;
            bool endX = false;
            bool endY = false;

            if (isReverse) // 역방향으로 움직일 때
            { 
                if ((perDx >= 0.0f && x <= defPos.x) || (perDx < 0.0f && x >= defPos.x)) // perDx는 양수로 설정했으면 쭉 양수기 때문에, 초기 위치(defPos.x)에 닿으면 endX = True;
                {
                    endX = true;
                }

                if ((perDy >= 0.0f && y <= defPos.y) || (perDy < 0.0f && y >= defPos.y))
                {
                    endY = true;
                }
                Vector3 v = new Vector3(-perDx, -perDy, defPos.z);
                transform.Translate(v);
            }
            else //정방향으로 움직일 떄
            {
                if ((perDx >= 0.0f && x >= defPos.x + moveX) || (perDx < 0.0f && x <= defPos.x + moveX))
                {
                    endX = true;
                }

                if ((perDy >= 0.0f && y >= defPos.y + moveY) || (perDy < 0.0f && y <= defPos.y + moveY))
                {
                    endY = true;
                }
                Vector3 v = new Vector3(perDx, perDy, defPos.z);
                transform.Translate(v);
            }
            

            /*연출부*/
            if (endX && endY)
            {
                if (isReverse) 
                {
                    transform.position = defPos;
                }
                isReverse = !isReverse;
                isCanMove = false;
                if (isMoveWhenOn == false)
                {
                    Invoke("Move", weight);
                }
            }
        }
    }

    private void Move() 
    {
        isCanMove = true;
    }

    private void Stop()
    {
        isCanMove = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            /*플레이어가 이 오브젝트의 자식 오브젝트가 되어서 부모 오브젝트를 따라 다니겠다.(중요)*/
            collision.transform.SetParent(transform);

            if (isMoveWhenOn)
            { 
                isCanMove = true;
            }
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            /*플레이어가 자식오브젝트에서 벗어나겠다(중요 : 아이템 집고 버릴 때 쓸만함)*/
            collision.transform.SetParent(null);
        }
    }

}
