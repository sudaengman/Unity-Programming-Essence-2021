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
        /* Ű �Է��� ���� ���� ���� �ӵ� */
        vx = 0;
        vy = 0;
        /* �̺�Ʈ : �����Ǵ� */
        if (Input.GetKey(KeyCode.RightArrow) /* bool ���� ��ȯ�Ѵ� ; = Input.GetKey("right"); */)
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
        /* ������������ �о��ִ� �ӵ� */
        //if (count == 0)
        //{
        //    rigid2D.velocity = new Vector2(5,0);
        //}
        //if (count == 50)
        //{
        //    rigid2D.velocity = new Vector2(0,0);
        //}
        //count = count + 1;

        this.transform.Translate(vx / 50, vy / 50, 0); // �ڷ���Ʈ
        this.GetComponent<SpriteRenderer>().flipX = flipflag;

        //isTrigger üũ�ϸ� 
    }
}
