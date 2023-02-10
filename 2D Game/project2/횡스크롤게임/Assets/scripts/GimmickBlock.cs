using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickBlock : MonoBehaviour
{
    public float length = 0.0f;

    bool isFall = false;        //�ٴڿ� �꿴���� �÷���
    bool isDelete = false;      //�ٴڿ� ���̸� ����� ������ �ƴ���
    float fadeTime = 0.5f;      //���̵� �ƿ� ���� �ð�
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rbody = GetComponent<Rigidbody2D>();
        rbody.bodyType = RigidbodyType2D.Static;
    }

    // Update is called once per frame
    void Update()
    {
        /*��� �÷��̾ ã�ڴ�.*/
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        /*���� �÷��̾ ã�Ҵٸ�*/
        if (player != null)
        {
            /*���� �÷��̾� ������ �Ÿ� ���*/
            float d = Vector2.Distance(transform.position, player.transform.position);
            /*���̰Ÿ��� ������ �Ÿ����� ũ��*/
            if (length >= d)
            {
                Rigidbody2D rbody = GetComponent<Rigidbody2D>();
                if (rbody.bodyType == RigidbodyType2D.Static)
                {
                    rbody.bodyType = RigidbodyType2D.Dynamic;
                }
            }
        
        }
        if (isFall)
        { 
            // ������ �� Ȯ�� �� --- ����� ������Ʈ�̸� ���̵�ƿ� ���� ȿ��
            fadeTime -= Time.deltaTime;
            Color col = GetComponent<SpriteRenderer>().color;
            col.a = fadeTime;

            GetComponent<SpriteRenderer>().color = col;
            //������ ���̵�Ÿ���� 0f �Ʒ��� �Ǹ� ���ӿ�����Ʈ �ڽ��� ���ְ� ���� ���̴�.
            if (fadeTime <= 0.0f)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDelete)
        { 
            isFall = true;
        }
    }
}
