using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
        transform.Translate(speed/50f,0,0);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Right wall")
        {
            speed = -speed;
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if (collision.gameObject.tag == "Left wall") 
        {
            speed = -speed;
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
