using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    /*�ٸ� ��ü�� ������ ����*/
    SpriteRenderer flip = new SpriteRenderer();

    // Start is called before the first frame update
    void Start()
    {
        /* ���׸� Ŭ���� - �ٸ� ��ü�� ������ ���� �Ʒ��� ���� �ڵ带 ��������Ѵ�. �� �׷��� ���� �� */
        /* this.GetComponent<������Ʈ �̸�>() */
        flip = this.GetComponent<SpriteRenderer>();
        
        flip.flipX = true;
        //this.GetComponent<SpriteRenderer>().flipX = true; �� �ʿ���� �̷������� �ϸ� Ŭ���� ���𵵵ǰ� ������ ������ �ְ�.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
        
    }
}
