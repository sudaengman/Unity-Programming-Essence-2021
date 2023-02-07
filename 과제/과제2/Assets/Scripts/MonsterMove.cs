using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    public float speed = 1f;
    public float vx = 2;
    Rigidbody2D rigid;
    SpriteRenderer ren;

    float count;
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
        //count += 0;
        //if (count > 100)
        //{
        //    count = 0;
        //    vx = -speed;
        //    isflip = false;
        //}
        //else 
        //{
        //    vx = speed;
        //    isflip = true;
        //}
    }

    private void FixedUpdate()
    {
        vx = 0;
        rigid.velocity = new Vector3(vx,transform.position.y,0);
        ren.flipX = isflip;
    }
}
