using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
/*�� �Ŵ��� �ҷ�����*/
using UnityEngine.SceneManagement;

public class gameStart : MonoBehaviour
{
    

    private void OnMouseDown()
    {
        SceneManager.LoadScene("SampleScene"); // = SceneManager.LoadScene(0); 0�� ���� �ҷ����ٴ�
        this.gameObject.SetActive(false);
    }

    private void OnMouseUp()
    {
        
    }
}
