using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    /*�ڵ��� �����ȭ : �� �߿� public speed�� ����Ƽ â�� ��������.*/
    /*����Ƽ���� ��� ��ǥ��� �Ǽ�(float)�� ����.*/
    public float speed = 5.0f;
    protected float hou = 3.0f;
    private float hey = 2.0f;

    public float angle = 90;

    public float maxCount = 50;
    int count = 0;

    public float maxY = 4;
    public

    // Start is called before the first frame update
    void Start()
    {
        int count = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        /*this �� ����Ƽ���� class�Ӹ� �ƴ϶� �� move Ŭ������ ���Ե� GameObject�� ������.*/
        /*������ ������ �ٲٱ� ���ؼ� translate()�� ��� �մϴ�*/
        /*��ũ��Ʈ�� ���� ������Ʈ���� ���� ������ �� ������ �˷��ִ� ������ �Ѵ�.*/
        //this.transform.Translate(speed / 50f, 0, 0); // �ʴ� x ������ 0.1��ŭ �̵��ϴ� ���� 60ȸ �ݺ��Ѵ�.

    }
    // FixedUpdate : �ʴ� 50���� �������ش�? ���� ������ ������ ������ �� ������ �� �����ϱ����� ���⿡ �־�д�
    private void FixedUpdate()
    {
        //this.transform.Translate(speed / 50f, speed / 50f, 0); // �ʴ� x ������ 0.1��ŭ �̵��ϴ� ���� 60ȸ �ݺ��Ѵ�.
        //this.transform.Rotate(0,0,angle/50);

        ///*1�ʿ� �� ���� 90���� ���� �ڵ�*/
        //count = count + 1;

        //if (count >= maxCount )
        //{
        //    this.transform.Rotate(0,0,angle);
        //    count = 0;
        //}

        this.transform.Translate(0,speed/ 50f,0);
        if ((speed / 50f) >= 4)
        {
            transform.Translate(speed/50f,0,0);

        }
    }
}
