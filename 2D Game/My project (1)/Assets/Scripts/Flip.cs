using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    /*다른 객체를 가져올 떄는*/
    SpriteRenderer flip = new SpriteRenderer();

    // Start is called before the first frame update
    void Start()
    {
        /* 제네릭 클래스 - 다른 객체를 가져올 때는 아래와 같은 코드를 적어줘야한다. 안 그러면 에러 뜸 */
        /* this.GetComponent<컴포넌트 이름>() */
        flip = this.GetComponent<SpriteRenderer>();
        
        flip.flipX = true;
        //this.GetComponent<SpriteRenderer>().flipX = true; 다 필요없고 이런식으로 하면 클래스 선언도되고 가져와 쓸수도 있고.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
        
    }
}
