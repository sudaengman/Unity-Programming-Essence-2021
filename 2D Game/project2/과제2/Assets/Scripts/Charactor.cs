using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactor : MonoBehaviour
{
    public float speed = 2;
    public float jumpPower = 2;
    public float vx;
    public string PlayerAni;

    bool jumpstart = false;
    bool jumpFlag = false;


    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.freezeRotation = true;
        //rigid.constraints = RigidbodyConstraints2D.FreezePositionZ;
        rigid.gravityScale = 1;

        
    }

    // Update is called once per frame
    void Update()
    {
        vx = 0;
        PlayerAni = "";
        if (Input.GetKey(KeyCode.RightArrow))
        {
            vx = speed;
            PlayerAni = "Right";
            
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            vx = -speed;
            PlayerAni = "Left";
        }
        if (Input.GetKey(KeyCode.Space) && jumpFlag)
        {
            jumpFlag = false;
            if (jumpstart == false)
            {
                jumpstart = true;
            }
            else
            {
                jumpstart = false;
            }
            
        }
    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector3(vx, 0, 0);

        if (jumpstart)
        {
            rigid.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
        
        }

        GetComponent<Animator>().Play(PlayerAni);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        jumpFlag = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        jumpFlag = false;
    }


}
