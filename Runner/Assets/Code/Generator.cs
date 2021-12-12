using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    /// <summary>
    /// Объекты спавна
    /// </summary>
    public GameObject[] tilePrefabs;
    private List<GameObject> _tiles = new List<GameObject>();
    private float _spawnPos = 0;
    [SerializeField] private float tileLength = 100;
    [SerializeField] private bool isHouseSpawn;

    public Transform player;
    [SerializeField] private int startTiles = 6;

    // Спавн первых объектов
    void Start()
    {
        for(int i = 0; i<startTiles; i++)
        {
            if (!isHouseSpawn)
                SpawnTile(Random.Range(0, tilePrefabs.Length), 0);
            else
                SpawnTile(Random.Range(0, tilePrefabs.Length), -90);
        }
    }

    void Update()
    {
        if(player.position.z - 60 > _spawnPos - (startTiles * tileLength)) // Если объект спавна находится позади игрока, то происходит удаление этого объекта и спавн нового уже перед игроком
        {
            if (!isHouseSpawn)
                SpawnTile(Random.Range(0, tilePrefabs.Length), 0);
            else
                SpawnTile(Random.Range(0, tilePrefabs.Length), -90);

            DeleteTile();
        }
    }

    // Спавн объектов
    void SpawnTile(int tileindex, int euler)
    {
        GameObject tile = Instantiate(tilePrefabs[tileindex], transform.forward * _spawnPos, Quaternion.Euler(euler, 0, 0));
        _tiles.Add(tile);
        _spawnPos += tileLength;
    }

    // Удаление объектов
    void DeleteTile()
    {
        Destroy(_tiles[0]);
        _tiles.RemoveAt(0);
    }
}
