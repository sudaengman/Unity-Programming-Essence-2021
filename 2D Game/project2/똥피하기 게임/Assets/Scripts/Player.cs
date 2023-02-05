using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    string nowAnime = "";

    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
    }

    // Update is called once per frame
    

    public void Move()
    {
        nowAnime = "";
        if (Input.GetKey(KeyCode.RightArrow))
        {
            /*Time.deltaTime : �������� ��� ��ǻ�Ϳ��� �����ϰ� �Ȱ��� ������ִ� ����?*/
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
        /*�÷��̾��� y��ǥ���� ã��*/
        float playerYposition = this.transform.position.y;

        if (collision.gameObject.tag == "Right wall")
        {
            this.transform.position = new Vector3(-10,playerYposition);
        }

        if (collision.gameObject.tag == "Left wall")
        {
            this.transform.position = new Vector3(10,playerYposition);
        }
    }
}
