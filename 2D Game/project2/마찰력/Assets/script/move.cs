using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed = 3;
    Rigidbody2D rigid;
    public float vx;
    public float jumpPower = 2;


    bool jumpFlag = false;
    bool jump = false;
    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        rigid.freezeRotation = false;
        rigid.gravityScale = 1;
        rigid.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    // Update is called once per frame
    void Update()
    {
        vx = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            vx = - speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            vx = speed;
        }
        if (Input.GetKey(KeyCode.Space) && jumpFlag)
        {
            if (jump == false)
            {
                jump = true;
            }else
            {
                jump = false;
            }    
        }
    }
    private void FixedUpdate()
    {
        rigid.velocity = new Vector3(vx,0,0);
        if(jump)
        {
            jump = false;
            rigid.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse); 

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumpFlag = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        jumpFlag = false;
    }
}
