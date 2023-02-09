using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterMove : MonoBehaviour
{
    public float speed = 1f;
    public float vx = 2;
    Rigidbody2D rigid;
    SpriteRenderer ren;

    public float Count = 0;
    bool isflip = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.freezeRotation = true;

        ren = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Count += 1;
        if (Count == 300)
        {
            Count = 0;
            vx = -vx;
            isflip = !isflip;
        }
    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector3(vx,0,0);
        ren.flipX = isflip;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag == "Player")
            { 
                collision.gameObject.gameObject.SetActive(false);
                
            }
            
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "stone(Clone)")
        {
            this.gameObject.SetActive(false);
        }
    }
}
