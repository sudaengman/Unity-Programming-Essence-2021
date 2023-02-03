using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * 
 * 
 */

public class GIrl : MonoBehaviour
{
    public string Front = "Front";
    public string Back = "Back";
    public string Right = "Right";
    public string Left = "Left";

    string nowAnime = "";

    public GameObject frefabread;

    // Start is called before the first frame update
    void Start()
    {
        nowAnime = Front;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            nowAnime = Back;
        }
        if (Input.GetKey("down"))
        {
            nowAnime = Front;
        }
        if (Input.GetKey("right"))
        {
            nowAnime = Right;
        }
        if (Input.GetKey("left"))
        {
            nowAnime = Left;
        }
    }

    private void FixedUpdate()
    {
        this.GetComponent<Animator>().Play(nowAnime);
    }
    private void OnMouseDown()
    {
        /*게임오브젝트를 만들겠다 (외우기)*/
        GameObject _newgameObject = Instantiate(frefabread) as GameObject;
        

        float ixRand = Random.Range(-10f, 10f);
        float iyRand = Random.Range(-10f, 10f);

        _newgameObject.transform.Translate(new Vector3(ixRand, iyRand, 0));
        //_newgameObject.transform.position = (new Vector3(ixRand, iyRand, 0));
    }
}
