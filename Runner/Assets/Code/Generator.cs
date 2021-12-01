using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    private List<GameObject> tiles = new List<GameObject>();
    private float spawnPos = 0;
    [SerializeField] private float tileLength = 100;
    [SerializeField] private bool isHouseSpawn;

    public Transform player;
    [SerializeField] private int startTiles = 6;
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

    // Update is called once per frame
    void Update()
    {
        if(player.position.z - 60 > spawnPos - (startTiles * tileLength))
        {
            if (!isHouseSpawn)
                SpawnTile(Random.Range(0, tilePrefabs.Length), 0);
            else
                SpawnTile(Random.Range(0, tilePrefabs.Length), -90);

            DeleteTile();
        }
    }
    void SpawnTile(int tileindex, int euler) //transform.rotation
    {
        GameObject tile = Instantiate(tilePrefabs[tileindex], transform.forward * spawnPos, Quaternion.Euler(euler, 0, 0));
        tiles.Add(tile);
        spawnPos += tileLength;
    }
    void DeleteTile()
    {
        Destroy(tiles[0]);
        tiles.RemoveAt(0);
    }
}
