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
    {   /*ȭ������� ������ ���ӿ�����Ʈ�� ������� �ڵ�*/
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
