using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followcamera : MonoBehaviour
{
    public GameObject player = GameObject.Find("Player");
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mob = new Vector3(player.transform.position.x, player.transform.position.y, 5);
        /* ¿¡·¯¶ä */
        //this.gameObject.transform.position.x = Player.transform.position.x;
        this.gameObject.transform.position = mob;
        Debug.Log(this.gameObject.transform.position.x);
    }
}
