using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public string targetGOName;
    public float speed = 1;
    


    GameObject targetObject;
    Rigidbody2D rigdBody;
    // Start is called before the first frame update
    void Start()
    {
        targetObject = GameObject.Find("Player");

        rigdBody = GetComponent<Rigidbody2D>();
        rigdBody.gravityScale = 0;
        rigdBody.constraints = RigidbodyConstraints2D.FreezeRotation;

    }

    // Update is called once per frame
    void Update()
    {
        /*타겟에 귀신꺼를 뺴면 방향정보가 나온다.*/
        Vector2 dir = (targetObject.transform.position - this.transform.position).normalized;

        float vx = dir.x * speed;
        float vy = dir.x * speed;

        rigdBody.velocity = new Vector2(vx, vy);

        this.GetComponent<SpriteRenderer>().flipX = (vx < 0);

    }
}
