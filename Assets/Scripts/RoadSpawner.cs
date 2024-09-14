using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject[] Tiles;
    public int StartTilesCount = 5;
    public Transform Player;
    private List<GameObject> tiles = new List<GameObject>();
    private Vector3 spawnPosition;
    public float SpawnDistance = 100f;
    public float DestroyDistance = 20f;


    void Start()
    {
        spawnPosition = transform.position;
        for (int i = 0; i < StartTilesCount; i++)
        {
            CreateTile();
        }
    }
    void Update()
    {
        if (spawnPosition.z - Player.position.z < SpawnDistance)
        {
            CreateTile();
        }
        if (Player.position.z - tiles[0].transform.position.z > DestroyDistance)
        {
            Destroy(tiles[0]);
            tiles.RemoveAt(0);
        }
    }

    private void CreateTile()
    {
        int randomIndex = Random.Range(0, Tiles.Length);
        GameObject newTile = Instantiate(Tiles[randomIndex], spawnPosition, Quaternion.identity);
        tiles.Add(newTile);
        spawnPosition.z += newTile.transform.localScale.z;
    }
}
