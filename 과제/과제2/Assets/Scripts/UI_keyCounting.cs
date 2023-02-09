using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_keyCounting : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TMP_Text>().text = GameObject.Find("Player").GetComponent<Move>().keyCount.ToString();
    }
}
