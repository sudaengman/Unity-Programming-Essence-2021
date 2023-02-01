using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suffle : MonoBehaviour
{
    //SpriteRenderer Flip = new SpriteRenderer();

    public float speed = 5.0f;
    

    // Start is called before the first frame update
    void Start()
    {
       // Flip = this.GetComponent<SpriteRenderer>();
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        this.transform.Translate(speed/50f, 0, 0);
        if (this.transform.position.x >= 6.1f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            speed = -speed;
        }
        if (this.transform.position.x <= -6.1f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            speed = -speed;
        }
        
        
}
}
