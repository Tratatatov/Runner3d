using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    private Vector3 offset;
    void Start()
    {
        offset = transform.position;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(offset.x,offset.y,Player.position.z + offset.z);
    }
}
