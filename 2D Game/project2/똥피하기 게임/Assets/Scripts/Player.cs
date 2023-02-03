using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
    }

    // Update is called once per frame
    

    public void Move()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            /*Time.deltaTime : �������� ��� ��ǻ�Ϳ��� �����ϰ� �Ȱ��� ������ִ� ����?*/
            this.transform.Translate(speed*Time.deltaTime,0,0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            this.transform.Translate(0, 0, 0);
        
        }
    }
}
