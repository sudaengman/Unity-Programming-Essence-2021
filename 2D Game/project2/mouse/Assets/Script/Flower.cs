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
        /*���콺�� �ٿ��Ҷ� ����*/
        speed = maxSpeed;
    }

    private void OnMouseUp()
    {
        /*���콺�� �� �Ҷ� �����*/
        speed = 0;
    }

}
