using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{

    public float moveX = 0.0f;          // x�� �̵��Ÿ�
    public float moveY = 0.0f;          // y�� �̵��Ÿ�
    public float times = 0.0f;
    public float weight = 0.0f;         // ���� �ð�
    public bool isMoveWhenOn = false;   //

    public bool isCanMove = true;

    float perDx;                        // 1 �����Ӵ� x �̵� ��
    float perDy;                        // 1 �����Ӵ� y �̵� ��
    Vector3 defPos;                     // �ʱ� ��ġ
    bool isReverse = false;             //

    // Start is called before the first frame update
    void Start()
    {
        defPos = this.transform.position;
        /* 1�����ӿ� �ɸ��� �ð� == �̵��ð� */
        float timeStep = Time.fixedDeltaTime;
        /* 1�������� x �̵� ��*/
        perDx = moveX / (1.0f / timeStep * times);

        perDy = moveY / (1.0f / timeStep * times);

        if (isMoveWhenOn)
        {
            isCanMove = false;
        }
    }

    /*���� ������Ʈ�� �۵��ڵ�*/
    private void FixedUpdate()
    {
        if (isCanMove) 
        {
            float x = transform.position.x;
            float y = transform.position.y;
            bool endX = false;
            bool endY = false;

            if (isReverse) // ���������� ������ ��
            { 
                if ((perDx >= 0.0f && x <= defPos.x) || (perDx < 0.0f && x >= defPos.x)) // perDx�� ����� ���������� �� ����� ������, �ʱ� ��ġ(defPos.x)�� ������ endX = True;
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
            else //���������� ������ ��
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
            

            /*�����*/
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
            /*�÷��̾ �� ������Ʈ�� �ڽ� ������Ʈ�� �Ǿ �θ� ������Ʈ�� ���� �ٴϰڴ�.(�߿�)*/
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
            /*�÷��̾ �ڽĿ�����Ʈ���� ����ڴ�(�߿� : ������ ���� ���� �� ������)*/
            collision.transform.SetParent(null);
        }
    }

}
