using UnityEngine;

public class ObjectsSpawner : MonoBehaviour
{
    public GameObject[] ObjectsToSpawn;
    public float TimeBeforeFirstSpawn;
    public float RepeatRate;
    public Transform SpawnPosition;
    void Start()
    {
        InvokeRepeating("Spawn", TimeBeforeFirstSpawn, RepeatRate);
    }

    void Update()
    {

    }
    private void Spawn()
    {
        int randomObjectIndex = Random.Range(0, ObjectsToSpawn.Length);
        Instantiate(ObjectsToSpawn[randomObjectIndex], SpawnPosition.position, Quaternion.identity);
    }
}
