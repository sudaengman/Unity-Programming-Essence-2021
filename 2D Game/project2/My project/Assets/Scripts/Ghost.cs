using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float speed = 1;
    Rigidbody2D rigid;

    bool fCollision = false;
    public GameObject goTarget;

    void Start()
    {
        Time.timeScale = 1;
        rigid = GetComponent<Rigidbody2D>();
        rigid.gravityScale = 0;
        rigid.constraints = RigidbodyConstraints2D.FreezeRotation;

    }

    void Update()
    {
        rigid.velocity = new Vector2(speed, 0);
    }

    void FixedUpdate()
    {
        
    }

    
    /*�浹�Ǹ� ȣ���̵Ǵ� �Լ�(�̺�Ʈ)*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        speed = -speed;
        this.GetComponent<SpriteRenderer>().flipX = (speed < 0);

        //fCollision = true;

        //if (collision.gameObject.name == "LBlock")
        if (collision.gameObject.name == goTarget.name)
        {
            
            GameObject _goTarget = GameObject.Find(collision.gameObject.name);
            if (_goTarget != null)
            { 
                /*���� ������Ʈ ��Ȱ��ȭ ��Ű�� �ڵ� (�ܿ��)*/
                /*��� ������Ʈ �ľ� �� ����*/
                _goTarget.SetActive(false);
            }
            
        }

    }
}
