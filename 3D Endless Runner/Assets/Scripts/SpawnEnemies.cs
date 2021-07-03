using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemy;
    public float maxZ;
    public float minZ;
    public float timeBetweenSpawn;
    private float spawnTime;
    private int spawn_type = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawn_type = Random.Range(1, 4);
        if (Time.time > spawnTime)
        {
            Spawn_Enemies();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }
    void Spawn_Enemies()
    {
        float randomZ = Random.Range(minZ, maxZ);
        Instantiate(enemy, transform.position + new Vector3(-20, 3, randomZ), transform.rotation);
        Instantiate(enemy, transform.position + new Vector3(30, 3, randomZ), transform.rotation);
        //Instantiate(enemy, transform.position + new Vector3(2.20f, 3, randomZ), transform.rotation);
    }
}
