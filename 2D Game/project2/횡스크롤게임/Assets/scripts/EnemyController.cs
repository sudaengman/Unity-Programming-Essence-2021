using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3.0f;
    public string direction = "left";   // 움직이는 방향
    public float range = 0.0f;          // 움직이는 범위
    Vector3 defPos;
    // Start is called before the first frame update
    void Start()
    {
        if (direction == "right")
        {
            transform.localScale = new Vector2(-1, 1);
        }
        /* Enemy 오브젝트 시작 위치값 defPos 변수에 담아두기*/
        defPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (range > 0.0f)
        {
            if (transform.position.x < defPos.x - (range / 2)) // 시작 위치값+범위보다 현재 위치값이 뒤에 있을 경우 
            {
                direction = "right";
                transform.localScale = new Vector2(-1, 1);

            }
            if (transform.position.x > defPos.x + (range / 2)) // 시작 위치값+범위보다 현재 위치값이 앞에 있을 경우
            { 
                direction= "left";
                transform.localScale = new Vector3(1, 1);

            
            }
        }
    }
    private void FixedUpdate()
    {
        // 속도 갱신
        Rigidbody2D rbody = GetComponent<Rigidbody2D>();
        if (direction == "right")
        {
            rbody.velocity = new Vector2(speed, rbody.velocity.y);
        }
        else
        {
            rbody.velocity = new Vector2(-speed, rbody.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (direction == "right")
        {
            direction = "left";
            transform.localScale = new Vector2(1, 1);
        }
        else
        { 
            direction= "right";
            transform.localScale = new Vector2(-1, 1);
        }
    }
}
