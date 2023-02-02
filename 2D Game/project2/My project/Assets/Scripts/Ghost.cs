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

    
    /*충돌되면 호출이되는 함수(이벤트)*/
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
                /*게임 오브젝트 비활성화 시키는 코드 (외우기)*/
                /*상대 오브젝트 파악 후 삭제*/
                _goTarget.SetActive(false);
            }
            
        }

    }
}
