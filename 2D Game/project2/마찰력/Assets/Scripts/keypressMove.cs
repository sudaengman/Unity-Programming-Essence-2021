using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keypressMove : MonoBehaviour
{
    public float speed = 3;
    public float jumpPower = 2;

    float vx = 0;

    bool leftFlag = false;
    bool pushFlag = false;
    bool jumpFlag = false;

    /*발에 뭔가가 닿았는지 안닿았는지*/
    bool groundFlag = false;

    Rigidbody2D rbody;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Move()
    { 
    
    }

    // Update is called once per frame
    void Update()
    {
        vx = 0;
        if (Input.GetKey("right"))
        {
            vx = speed;
            leftFlag = false;

        
        }
        if (Input.GetKey("left"))
        {
            vx = -speed;
            leftFlag = false;


        }

        /*스페이스 누르고 땅에 닿여있는 상태일때만 점프하기*/
        if (Input.GetKey("space") && groundFlag)
        {
            if (pushFlag == false)
            {
                jumpFlag = true;
                pushFlag = true;
            }
            else 
            {
                pushFlag = false;            
            }


        }

        
    }
    private void FixedUpdate()
    {
        rbody.velocity = new Vector2(vx, rbody.velocity.y);
        this.GetComponent<SpriteRenderer>().flipX = leftFlag;

        if (jumpFlag)
        { 
            jumpFlag= false;
            /*AddForce : y방향으로 힘을 줘서 위로 띄우는*/
            rbody.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
        
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        groundFlag = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        groundFlag = false;
    }
}
