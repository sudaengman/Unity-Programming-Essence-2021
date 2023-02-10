using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickBlock : MonoBehaviour
{
    public float length = 0.0f;

    bool isFall = false;        //바닥에 닿였는지 플래그
    bool isDelete = false;      //바닥에 닿이면 사라질 것인지 아닌지
    float fadeTime = 0.5f;      //페이드 아웃 연출 시간
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rbody = GetComponent<Rigidbody2D>();
        rbody.bodyType = RigidbodyType2D.Static;
    }

    // Update is called once per frame
    void Update()
    {
        /*계속 플레이어를 찾겠다.*/
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        /*만약 플레이어를 찾았다면*/
        if (player != null)
        {
            /*돌과 플레이어 사이의 거리 계산*/
            float d = Vector2.Distance(transform.position, player.transform.position);
            /*사이거리가 설정한 거리보다 크면*/
            if (length >= d)
            {
                Rigidbody2D rbody = GetComponent<Rigidbody2D>();
                if (rbody.bodyType == RigidbodyType2D.Static)
                {
                    rbody.bodyType = RigidbodyType2D.Dynamic;
                }
            }
        
        }
        if (isFall)
        { 
            // 떨어진 것 확인 후 --- 사라질 오브젝트이면 페이드아웃 연출 효과
            fadeTime -= Time.deltaTime;
            Color col = GetComponent<SpriteRenderer>().color;
            col.a = fadeTime;

            GetComponent<SpriteRenderer>().color = col;
            //설정한 페이드타임이 0f 아래가 되면 게임오브젝트 자신을 없애게 만들 것이다.
            if (fadeTime <= 0.0f)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDelete)
        { 
            isFall = true;
        }
    }
}
