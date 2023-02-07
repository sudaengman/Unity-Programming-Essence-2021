using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

/*유니티 유아이 클래스를 참조할려면 아래와같이 써 줘야함*/
using UnityEngine.UI;
using TMPro;
public class showtxtUI : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        /*new Count.value로 할당 할 필요가 없다. 왜냐하면 value가 static이기 떄문에 이미 공용 메모리 안에 있기 때문이다.*/
        GetComponent<TMP_Text>().text = Count.value.ToString(); // ToStirng() => 스트링값으로 바꿔주겠다. Text.text는 string 변수이기 때문이다.
    }
}
