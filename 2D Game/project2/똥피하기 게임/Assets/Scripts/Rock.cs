using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Rock : MonoBehaviour
{

    public GameObject rockduple;
    public GameObject _newStone;
    public GameOver gameover;
    public double count = 0;
    public Rigidbody2D rigid;
    
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.gravityScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        count += 1;
        if (count == 60)
        {


            float xran = Random.Range(-10f, 10f);
            _newStone = Instantiate(rockduple) as GameObject;
            _newStone.transform.position = (new Vector3(xran, 10, 0));
            
            count = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider != null)
        {
            if (collision.gameObject.name == "floor") 
            {
                Destroy(this.gameObject);
            }
            if (collision.gameObject.name == "Player")
            {
                
                collision.gameObject.SetActive(false);
                gameover.gameObject.SetActive(true);
                Time.timeScale = 0;
                Destroy(this.gameObject);

            }
            
        }
    }
}
