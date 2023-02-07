using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    private void LateUpdate()
    {
        Vector3 pos = this.transform.position;
        pos.z = -10;
        Camera.main.gameObject.transform.position = pos;
    }
}
