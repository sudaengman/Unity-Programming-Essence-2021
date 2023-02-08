using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 3;
    public float jumpPower = 8;
    public float vx;
    Rigidbody2D rigid ;

    public float keyCount = 0;

    bool groundFlag = false;
    bool pushFlag = false;
    bool jumpFlag = false;

    public string PlayerAni;
    // Start is called before the first frame update
    void Start()
    {
        /* 중력 관련 기본설정 */
        rigid = GetComponent<Rigidbody2D>();
        //rigid.constraints = RigidbodyConstraints2D.FreezePositionY;
        //rigid.gravityScale = 1;
        rigid.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        vx = 0;
        PlayerAni = "";
        pushFlag = false;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            vx = -speed;
            PlayerAni = "Left";
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            vx = speed;
            PlayerAni = "Right";
        }

        if (Input.GetKey(KeyCode.Space) && groundFlag)
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
        GetComponent<Animator>().Play(PlayerAni);
    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector3(vx,rigid.velocity.y);

        if (jumpFlag)
        {
            jumpFlag = false;
            rigid.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag == "Key")
            {
                collision.gameObject.SetActive(false);
                keyCount += 1;
            }
        }
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
