using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1.0f;
    public GameObject monster;
    Rigidbody2D rigid;
    public float vx;
    public float vy;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.gravityScale = 0;
        rigid.freezeRotation = true;
    }




    // Update is called once per frame
    void Update()
    {
        
        this.transform.Translate(vx/50f,vy/50f,0);
    }
    void FixedUpdate()
    {
        vx = 0;
        vy = 0;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            vy = speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            vy = -speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            vx = -speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            vx = speed;
        }
    }
}
