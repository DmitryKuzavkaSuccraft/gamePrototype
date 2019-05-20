using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyToSpawn;
    private GameObject player;
    private float spawnDelay = 1;
    private int spawnSize = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Character");

        if ( Time.time >= spawnDelay && player != null && spawnSize != 0)
        {
            spawnSize -= 1;
            spawnDelay = Time.time + Random.Range(0.5F, 2);
            Spawn();
        }
    }
    void Spawn()
    {
        GameObject vfx;

        vfx = Instantiate(enemyToSpawn, gameObject.transform.position, Quaternion.identity);
    }
}
