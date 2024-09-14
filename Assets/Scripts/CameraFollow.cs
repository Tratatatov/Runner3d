using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    public float LerpValue;
    private Vector3 newPosition;
    private Vector3 offset;
    void Start()
    {
        offset = transform.position;
    }

    void Update()
    {
        newPosition.x = Mathf.Lerp(transform.position.x,Player.position.x, Time.deltaTime * LerpValue);
        newPosition.y = offset.y;
        newPosition.z = Player.position.z + offset.z;
        transform.position = newPosition;
        //transform.position = new Vector3(offset.x,offset.y,Player.position.z + offset.z);
    }
}
