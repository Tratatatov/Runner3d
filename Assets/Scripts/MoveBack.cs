using UnityEngine;

public class MoveBack : MonoBehaviour
{
    public float Speed;


    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * Speed);
    }
}
