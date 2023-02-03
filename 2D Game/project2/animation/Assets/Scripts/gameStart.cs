using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
/*씬 매니저 불러오기*/
using UnityEngine.SceneManagement;

public class gameStart : MonoBehaviour
{
    

    private void OnMouseDown()
    {
        SceneManager.LoadScene("SampleScene"); // = SceneManager.LoadScene(0); 0번 씬을 불러오겟다
        this.gameObject.SetActive(false);
    }

    private void OnMouseUp()
    {
        
    }
}
