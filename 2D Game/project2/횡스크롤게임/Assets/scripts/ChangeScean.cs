using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*씬 쓸때는 아래와같이 쓰기*/
using UnityEngine.SceneManagement;

public class ChangeScean : MonoBehaviour
{
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Load() 
    {
        SceneManager.LoadScene(sceneName);
    }
}
