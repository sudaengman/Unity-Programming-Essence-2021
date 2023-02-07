using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*ui 컴포넌트를 제어할수있게 가져오기*/
using UnityEngine.UI;

public class ShowImage : MonoBehaviour
{

    public int Count = 0;
   
    // Update is called once per frame
    void Update()
    {
        if (Count > 10)
        {
            
            GetComponent<Image>().enabled = false;
        }
        else
        { 
            GetComponent<Image>().enabled = true;
        }
    }
}
