using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

/*����Ƽ ������ Ŭ������ �����ҷ��� �Ʒ��Ͱ��� �� �����*/
using UnityEngine.UI;
using TMPro;
public class showtxtUI : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        /*new Count.value�� �Ҵ� �� �ʿ䰡 ����. �ֳ��ϸ� value�� static�̱� ������ �̹� ���� �޸� �ȿ� �ֱ� �����̴�.*/
        GetComponent<TMP_Text>().text = Count.value.ToString(); // ToStirng() => ��Ʈ�������� �ٲ��ְڴ�. Text.text�� string �����̱� �����̴�.
    }
}
