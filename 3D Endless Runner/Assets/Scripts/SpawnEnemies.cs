using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemy;
    public GameObject jetpack_enemy;
    public GameObject jetpack_pickup;
    public GameObject jetpack_slowmo_pickup;
    public float maxZ;
    public float minZ;
    public float timeBetweenSpawn;
    private float spawnTime;
    private int spawn_type = 0;
    private int spawn_after_time_jetpack_pickups = 0;
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

        if(PlayerController.jetpack_higher == 1)
        {
            float obstacle_position = Random.Range(0, 3);
            if (obstacle_position == 0)
            {
                float pickup_pos = Random.Range(0, 3);
                spawn_after_time_jetpack_pickups++;
                //float pickup_type = Random.Range(0, 2);
                if (spawn_after_time_jetpack_pickups % 3 == 0)
                {
                    if (pickup_pos == 0)
                        Instantiate(jetpack_slowmo_pickup, transform.position + new Vector3(2, 6, randomZ + 30), Quaternion.Euler(90f, 90f, 270f));
                    else if (pickup_pos == 1)
                        Instantiate(jetpack_slowmo_pickup, transform.position + new Vector3(5, 6, randomZ + 30), Quaternion.Euler(90f, 90f, 270f));
                    else if (pickup_pos == 2)
                        Instantiate(jetpack_slowmo_pickup, transform.position + new Vector3(7, 6, randomZ + 30), Quaternion.Euler(90f, 90f, 270f));
                }
                else
                {
                    if (pickup_pos == 0)
                        Instantiate(jetpack_pickup, transform.position + new Vector3(2, 6, randomZ + 30), Quaternion.Euler(90f, 90f, 270f));
                    else if (pickup_pos == 1)
                        Instantiate(jetpack_pickup, transform.position + new Vector3(5, 6, randomZ + 30), Quaternion.Euler(90f, 90f, 270f));
                    else if (pickup_pos == 2)
                        Instantiate(jetpack_pickup, transform.position + new Vector3(7, 6, randomZ + 30), Quaternion.Euler(90f, 90f, 270f));
                }
                
                Instantiate(jetpack_enemy, transform.position + new Vector3(2, 5.5f, randomZ - 5), transform.rotation);
                Instantiate(jetpack_enemy, transform.position + new Vector3(5, 5.5f, randomZ - 5), transform.rotation);
            }
            else if (obstacle_position == 1)
            {
                float pickup_pos = Random.Range(0, 3);
                spawn_after_time_jetpack_pickups++;
                //float pickup_type = Random.Range(0, 2);
                if (spawn_after_time_jetpack_pickups % 3 == 0)
                {
                    if (pickup_pos == 0)
                        Instantiate(jetpack_slowmo_pickup, transform.position + new Vector3(2, 6, randomZ + 30), Quaternion.Euler(90f, 90f, 270f));
                    else if (pickup_pos == 1)
                        Instantiate(jetpack_slowmo_pickup, transform.position + new Vector3(5, 6, randomZ + 30), Quaternion.Euler(90f, 90f, 270f));
                    else if (pickup_pos == 2)
                        Instantiate(jetpack_slowmo_pickup, transform.position + new Vector3(7, 6, randomZ + 30), Quaternion.Euler(90f, 90f, 270f));
                }
                else
                {
                    if (pickup_pos == 0)
                        Instantiate(jetpack_pickup, transform.position + new Vector3(2, 6, randomZ + 30), Quaternion.Euler(90f, 90f, 270f));
                    else if (pickup_pos == 1)
                        Instantiate(jetpack_pickup, transform.position + new Vector3(5, 6, randomZ + 30), Quaternion.Euler(90f, 90f, 270f));
                    else if (pickup_pos == 2)
                        Instantiate(jetpack_pickup, transform.position + new Vector3(7, 6, randomZ + 30), Quaternion.Euler(90f, 90f, 270f));
                }

                Instantiate(jetpack_enemy, transform.position + new Vector3(2, 5.5f, randomZ - 5), transform.rotation);
                Instantiate(jetpack_enemy, transform.position + new Vector3(8, 5.5f, randomZ - 5), transform.rotation);
            }
            else if(obstacle_position == 2)
            {
                float pickup_pos = Random.Range(0, 3);
                float pickup_type = Random.Range(0, 2);
                spawn_after_time_jetpack_pickups++;
                //float pickup_type = Random.Range(0, 2);
                if (spawn_after_time_jetpack_pickups % 3 == 0)
                {
                    if (pickup_pos == 0)
                        Instantiate(jetpack_slowmo_pickup, transform.position + new Vector3(2, 6, randomZ + 30), Quaternion.Euler(90f, 90f, 270f));
                    else if (pickup_pos == 1)
                        Instantiate(jetpack_slowmo_pickup, transform.position + new Vector3(5, 6, randomZ + 30), Quaternion.Euler(90f, 90f, 270f));
                    else if (pickup_pos == 2)
                        Instantiate(jetpack_slowmo_pickup, transform.position + new Vector3(7, 6, randomZ + 30), Quaternion.Euler(90f, 90f, 270f));
                }
                else
                {
                    if (pickup_pos == 0)
                        Instantiate(jetpack_pickup, transform.position + new Vector3(2, 6, randomZ + 30), Quaternion.Euler(90f, 90f, 270f));
                    else if (pickup_pos == 1)
                        Instantiate(jetpack_pickup, transform.position + new Vector3(5, 6, randomZ + 30), Quaternion.Euler(90f, 90f, 270f));
                    else if (pickup_pos == 2)
                        Instantiate(jetpack_pickup, transform.position + new Vector3(7, 6, randomZ + 30), Quaternion.Euler(90f, 90f, 270f));
                }

                Instantiate(jetpack_enemy, transform.position + new Vector3(5, 5.5f, randomZ - 5), transform.rotation);
                Instantiate(jetpack_enemy, transform.position + new Vector3(8, 5.5f, randomZ - 5), transform.rotation);
            }
        }

        //Instantiate(enemy, transform.position + new Vector3(2.20f, 3, randomZ), transform.rotation);
    }
}
