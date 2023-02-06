using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RandomCreate : MonoBehaviour
{
    /*
     *invoke();
     *invokeRepeating();
     *Cancleinvoke();
     */
    
    
    public float startSec = 2.0f;
    public float intervalSec = 1.0f;
    public float count = 0;
    /*�������� ���� ���ӿ�����Ʈ*/
    public GameObject newPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("CreatePrefab_Invoke",intervalSec); // 1�� �� �� �� ����
        //InvokeRepeating("CreatePrefab_Repeat", startSec, intervalSec); // 2�� �� ����ǰ� 1�ʸ��� �ݺ�
    }

    private void FixedUpdate()
    {
        count++;
        if (count == 30)
        {
            intervalSec = Random.Range((float)0.1, 1);
            count = 0;
            Invoke("CreatePrefab_Invoke", intervalSec);
        }
    }



    void CreatePrefab_Invoke()
    {
        //Debug.LogWarning("�κ�ũ �Լ� ȣ��");
        Vector3 area = this.transform.position;

        Vector3 newPos = this.transform.position;
        newPos.x = Random.Range(area.x - 1, area.x + 1);
        newPos.y = area.y - 2;
        newPos.z = -5;

        GameObject newGo = Instantiate(newPrefab) as GameObject;
        newGo.transform.position = newPos;

    }

    void CreatePrefab_Repeat()
    {
        /*��������Ʈ�� ����� �� �� ����*/
        //Vector3 area = GetComponent<SpriteRenderer>().bounds.size;
    }
}
