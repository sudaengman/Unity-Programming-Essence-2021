using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Click : MonoBehaviour
{
    public GameObject _newhamberger;
    public GameObject newPrefab;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        _newhamberger = Instantiate(newPrefab) as GameObject;
    }
}
