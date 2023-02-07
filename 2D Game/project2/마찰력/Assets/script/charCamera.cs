using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.gameObject.transform.position; // 캐릭터의 포지션
        pos.z = -10;
        Camera.main.gameObject.transform.position = pos;
    }
}
