using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{

    public GameObject objPrefab;
    public float delayTime = 3.0f;
    public float fireSpeedX = -4.0f;
    public float fireSpeedY = 0.0f;
    public float length = 8.0f;

    GameObject player;  //��ź�� ���� ���
    GameObject GateObj; //�߻�ü�� ���� ��ġ
    float passedTimes = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        /*�ڽ����� �� ���ӿ�����Ʈ�� ã�� �� transform.find ���ָ� ��*/
        Transform tr = transform.Find("Gate");
        GateObj = tr.gameObject;

        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        passedTimes += Time.deltaTime;
        if (CheckLenghth(player.transform.position))
        {
            if (passedTimes > delayTime)
            {
                passedTimes = 0;

                Vector3 pos = new Vector3(GateObj.transform.position.x,
                                            GateObj.transform.position.y,
                                            GateObj.transform.position.z);
                /*pos ��ġ���� objprefab�� ����ڴ�.*/
                GameObject objBullet = Instantiate(objPrefab, pos, Quaternion.identity);

                Rigidbody2D rbody = objBullet.GetComponent<Rigidbody2D>();
                Vector2 v = new Vector2(fireSpeedX, fireSpeedY);
                
                rbody.AddForce(v, ForceMode2D.Impulse);
            }
        }
    }

    /*�����Ÿ� ���� �ȿ� ����� ��*/
    bool CheckLenghth(Vector2 targetPos)
    {
        bool ret = false;

        /*Ÿ������ : �÷��̾�� ���� ������ �Ÿ����� ���� d�� �ְڴ�.*/
        float d = Vector2.Distance(transform.position, targetPos);
        if (length >= d) // �Ÿ����� length(8) ���϶��,
        {
            ret = true;
        }
        return ret;
    }
}
