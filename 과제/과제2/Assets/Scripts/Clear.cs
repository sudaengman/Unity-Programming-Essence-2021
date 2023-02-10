using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour
{

    
    public GameObject GameClear;
    // Start is called before the first frame update
    void Start()
    {
        
        GameClear.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<Move>().keyCount == 3)
            {
                GameClear.SetActive(true);
                Time.timeScale = 0;
                
            }
        }
    }
}
