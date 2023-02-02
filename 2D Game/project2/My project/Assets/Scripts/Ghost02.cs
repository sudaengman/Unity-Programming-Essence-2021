using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ghost02 : MonoBehaviour
{
    public float speed = 1;
    public GameObject goTarget;
    Rigidbody2D rigid;
    public GameOver gameover;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Time.timeScale = 1;
        rigid.gravityScale = 0;
        rigid.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = new Vector2(speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        speed = -speed;
        GetComponent<SpriteRenderer>().flipX = (speed < 0);

        /* Ȥ�� ���� null�� ��� �����°� ����? */
        if (goTarget != null)
        {
            if (collision.gameObject.name == goTarget.name)
            {
                collision.gameObject.SetActive(false);
                Time.timeScale = 0;
                gameover.gameObject.SetActive(true);
                Invoke("ResetScene", 3.0f);


                

            } 

            //if (collision.gameObject.name == "RBlock")
            //{
            //    �浹�� �ְ� RBlock�̸� RBlock�� x������ 1 �̵��ϴ� �ڵ�
            //    collision.gameObject.transform.Translate(1, 0, 0);
            //    goTarget.SetActive(true);
            //} 
        }



    }


    void ResetScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
