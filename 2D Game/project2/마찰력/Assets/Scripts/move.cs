using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed = 5.0f;
    public float vx = 0;
    Rigidbody2D rigid;
    public float jumpPower = 2;
    public string anime = "";

    bool groundFlag = false;
    bool jumpFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.gravityScale = 1 ;
        rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        vx = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            vx = -speed;
            anime = "Left";
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            vx = speed;
            anime = "Right";
        }
        if (Input.GetKey("space") && groundFlag)
        {
            jumpFlag = true;
        }

        GetComponent<Animator>().Play(anime);
        
    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(vx,rigid.velocity.y);
        
        if (jumpFlag)
        {
            rigid.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        groundFlag = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        groundFlag = false;
    }
}
