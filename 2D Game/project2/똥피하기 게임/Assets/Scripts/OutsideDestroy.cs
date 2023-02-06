using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideDestroy : MonoBehaviour
{
    bool showFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   /*화면밖으로 나가면 게임오브젝트가 사라지는 코드*/
        if (GetComponent<Renderer>().isVisible)
        {
            showFlag = true;
        }
        else
        {
            if (showFlag)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
