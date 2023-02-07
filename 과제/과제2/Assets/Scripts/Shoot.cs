using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float maxCount = 60;
    public float count = 0;
    public float OffsetY = 1;
    public float throwPowerX = 4;
    public float throwPowerY = 8;
    public GameObject PrefabStone;
    Rigidbody2D rigid;

    bool leftFlag;
    bool pushFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            leftFlag = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            leftFlag = true;
        }
        if (Input.GetKey(KeyCode.Z))
        {
            count += 1;
            if (count == maxCount) 
            {
                count = 0;
                if (pushFlag == false)
                {
                    pushFlag = true;
                    Vector3 thro = this.transform.position;
                    thro.y += OffsetY;
                    GameObject newGameObject = Instantiate(PrefabStone) as GameObject;
                    thro.z = -5;
                    newGameObject.transform.position = thro;

                    Rigidbody2D throwRigid = newGameObject.GetComponent<Rigidbody2D>();
                    if (leftFlag)
                    {
                        throwRigid.AddForce(new Vector2(-throwPowerX, throwPowerY), ForceMode2D.Impulse);
                    }
                    else
                    {
                        throwRigid.AddForce(new Vector2(throwPowerX, throwPowerY), ForceMode2D.Impulse);
                    }
                    Destroy(newGameObject, 3) ;
                }
                else
                {
                    pushFlag = false;
                }
            }
            
        }
        
    }
}
