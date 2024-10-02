using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    //[SerializeField] private GameObject[] _tilePrefabs;
    //[SerializeField] private GameObject _tileWithoutObjects;
    [SerializeField] private int _startTilesCount = 3;
    [SerializeField] private float _spawnDistance = 100f;
    [SerializeField] private float _destroyDistance = 20f;
    [SerializeField] private TilePool _tilePool;
    private List<GameObject> _tilesOnTheRoad = new List<GameObject>();
    private Vector3 _spawnPosition;

    private void Start()
    {
        _spawnPosition = transform.position;
        for (int i = 0; i < _startTilesCount; i++)
        {
            SpawnBlankTile();
        }
    }

    private void Update()
    {
        if (TileShouldSpawn())
        {
            SpawnTile();
        }
        if (TileShouldDestroy())
        {
            _tilePool.ReturnToPool(_tilesOnTheRoad[0]);
            _tilesOnTheRoad.RemoveAt(0);
        }
    }

    private bool TileShouldDestroy() => GameManager.Instance.PlayerTransform.position.z - _tilesOnTheRoad[0].transform.position.z > _destroyDistance;
    private bool TileShouldSpawn() => _spawnPosition.z - GameManager.Instance.PlayerTransform.position.z < _spawnDistance;

    private void SpawnTile()
    {
        GameObject tile = _tilePool.GetRandomTileFromPool();
        tile.transform.position = _spawnPosition;
        _tilesOnTheRoad.Add(tile);
        _spawnPosition.z += tile.GetComponentInChildren<Ground>().transform.localScale.z;

    } 
    
    private void SpawnBlankTile()
    {
        GameObject tile = _tilePool.GetBlankTile();
        tile.transform.position = _spawnPosition;
        _tilesOnTheRoad.Add(tile);
        _spawnPosition.z += tile.GetComponentInChildren<Ground>().transform.localScale.z;
    }
}
