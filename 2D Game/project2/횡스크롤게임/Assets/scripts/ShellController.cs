using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController : MonoBehaviour
{
    /*���󰡼� ���� ���������.*/
    public float deleteTime = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, deleteTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
