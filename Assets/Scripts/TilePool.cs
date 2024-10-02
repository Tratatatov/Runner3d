using System.Collections.Generic;
using UnityEngine;

public class TilePool : MonoBehaviour
{
    [SerializeField] private GameObject[] _tiles;
    [SerializeField] private GameObject _blankTile;
    [SerializeField] private int _startTilesCount;
    private List<GameObject> _tilesPool = new List<GameObject>();
    private List<GameObject> _blankTilePool = new List<GameObject>();

    public GameObject GetRandomTileFromPool()
    {
        foreach (GameObject tile in _tilesPool)
        {
            if (!tile.activeInHierarchy)
            {
                tile.SetActive(true);
                return tile;
            }
        }

        GameObject newTile = Instantiate(_tiles[Random.Range(0, _tiles.Length)], transform);
        _tilesPool.Add(newTile);
        return newTile;
    }

    public GameObject GetBlankTile()
    {
        foreach (GameObject tile in _blankTilePool)
        {
            if (!tile.activeInHierarchy)
            {
                tile.SetActive(true);
                return tile;
            }
        }

        GameObject newTile = Instantiate(_blankTile, transform);
        _blankTilePool.Add(newTile);
        return newTile;
    }

    public void ReturnToPool(GameObject tile)
    {
        tile.SetActive(false);
    }

    private void Start()
    {
        CreatePool(_startTilesCount);
    }

    private void CreatePool(int count)
    {
        for (int i = 0; i < _tiles.Length; i++)
        {
            for (int j = 0; j < count; j++)
            {
                GameObject newTile = Instantiate(_tiles[i], transform);
                newTile.SetActive(false);
                _tilesPool.Add(newTile);
            }
        }
    }

    private void CreateBlankPool(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject newTile = Instantiate(_blankTile, transform);
            newTile.SetActive(false);
            _blankTilePool.Add(newTile);
        }
    }
}


