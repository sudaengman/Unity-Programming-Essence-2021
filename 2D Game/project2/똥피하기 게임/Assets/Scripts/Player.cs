using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    string nowAnime = "";
    public Rigidbody2D rigid;
    public GameOver gameover;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        speed = 5;
        rigid.freezeRotation = true;
        rigid.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    // Update is called once per frame
    

    public void Move()
    {
        nowAnime = "";
        if (Input.GetKey(KeyCode.RightArrow))
        {
            /*Time.deltaTime : 프레임을 모든 컴퓨터에서 동일하게 똑같이 만들어주는 변수?*/
            this.transform.Translate(speed*Time.deltaTime,0,0);
            nowAnime = "Right";
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(-speed * Time.deltaTime, 0, 0);
            nowAnime = "Left";
        }
    }

    private void FixedUpdate()
    {
        Move();
        this.GetComponent<Animator>().Play(nowAnime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*플레이어의 y좌표값을 찾기*/
        float playerYposition = this.transform.position.y;

        if (collision.gameObject.tag == "Right wall")
        {
            this.transform.position = new Vector3(-10,playerYposition);
        }

        if (collision.gameObject.tag == "Left wall")
        {
            this.transform.position = new Vector3(10,playerYposition);
        }

        if (collision.gameObject.tag == "stone")
        {
            Time.timeScale = 0;
            gameover.gameObject.SetActive(true);
            Destroy(this.gameObject);

        }
    }
}
