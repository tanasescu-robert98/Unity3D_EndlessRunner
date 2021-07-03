using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject obstacle;
    //public GameObject enemy;
    public float maxZ;
    public float minZ;
    public float timeBetweenSpawn;
    private float spawnTime;
    private int spawn_type = 0;
    // Start is called before the first frame update
    void Update()
    {
        spawn_type = Random.Range(1, 4);
        if(Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    // Update is called once per frame
    void Spawn()
    {
        float randomZ = Random.Range(minZ, maxZ);
        /*Instantiate(enemy, transform.position + new Vector3(-1.60f, 1, randomZ), transform.rotation);
        Instantiate(enemy, transform.position + new Vector3(0.30f, 2, randomZ), transform.rotation);
        Instantiate(enemy, transform.position + new Vector3(2.20f, 3, randomZ), transform.rotation);*/
        if (spawn_type == 1)
        {
            Instantiate(obstacle, transform.position + new Vector3(-1.60f, -1.91f, randomZ), transform.rotation);
            Instantiate(obstacle, transform.position + new Vector3(0.30f, -1.91f, randomZ), transform.rotation);
            Instantiate(obstacle, transform.position + new Vector3(2.20f, -1.91f, randomZ), transform.rotation);
        }
        else if(spawn_type == 2)
        {
            Instantiate(obstacle, transform.position + new Vector3(-1.60f, -1.91f, randomZ), transform.rotation);
            Instantiate(obstacle, transform.position + new Vector3(0.30f, -1.91f, randomZ), transform.rotation);
        }
        else if (spawn_type == 3)
        {
            Instantiate(obstacle, transform.position + new Vector3(-1.60f, -1.91f, randomZ), transform.rotation);
            Instantiate(obstacle, transform.position + new Vector3(2.20f, -1.91f, randomZ), transform.rotation);
        }
        else if (spawn_type == 3)
        {
            Instantiate(obstacle, transform.position + new Vector3(0.30f, -1.91f, randomZ), transform.rotation);
            Instantiate(obstacle, transform.position + new Vector3(2.20f, -1.91f, randomZ), transform.rotation);
        }
    }
}
