using UnityEngine;

public class SpawnerFollow : MonoBehaviour
{
    private Transform FollowPosition;
    private Vector3 position;
    private Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
        FollowPosition = Camera.main.transform;
    }

    void Update()
    {
        position.x = startPosition.x;
        position.y = startPosition.y;
        position.z = FollowPosition.position.z + startPosition.z;
        transform.position = position;
    }
}
