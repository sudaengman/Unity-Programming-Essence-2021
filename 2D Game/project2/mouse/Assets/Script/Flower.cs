using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    //public float rotateAngle = 0;
    //public float Angle = 360;

    public float maxSpeed = 50;
    public float speed = 50;
    // Start is called before the first frame update
    void Start()
    {
        //rotateAngle = 360;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        //rotateAngle = rotateAngle * (float)0.98;
        //this.transform.Rotate(0, 0, rotateAngle / 50);

        speed = speed * (float)0.97;
        this.transform.Rotate(0,0,speed);
    }

    private void OnMouseDown()
    {
        /*마우스를 다운할때 돌고*/
        speed = maxSpeed;
    }

    private void OnMouseUp()
    {
        /*마우스를 업 할때 멈춘다*/
        speed = 0;
    }

}
