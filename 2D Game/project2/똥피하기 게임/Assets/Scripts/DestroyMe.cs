using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    public GameOver gameover;
    //public float destroyTime = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        /*destroyTime�Ŀ� �� ���ӿ�����Ʈ�� �����ϰڴ�*/
        //Destroy(this.gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider != null)
        {
            if (collision.collider.gameObject.name == "Player" || collision.collider.gameObject.name == "floor")
            {
                Destroy(this.gameObject);
            }
        }
    }
}
