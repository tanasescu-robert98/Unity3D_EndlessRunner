using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject Pickup;
    public GameObject JetPack_Pickup;
    public GameObject SloMo_Pickup;
    public GameObject left_wall;
    public GameObject right_wall;
    public int canDeployPickpus = 0;
    public int canDeployJetPack_Pickup = 0;
    public int canDeploySloMo_Pickup = 0;
    public int Pickup_location = 0;
    public int JetPack_location = 0;
    public int SloMo_location = 0;
    public int next_is_empty = 0;
    public float maxZ;
    public float minZ;
    public float timeBetweenSpawn;
    private float spawnTime;
    private int spawn_type = 0;
    // Start is called before the first frame update
    void Update()
    {
        //spawn_type = Random.Range(1, 4);
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
        spawn_type = Random.Range(1, 4);
        //spawn_type = 1;
        if (next_is_empty == 1)
            spawn_type = 5;
        if (spawn_type == 1)
        {
            Instantiate(obstacle, transform.position + new Vector3(-1.60f, -1.91f, randomZ), transform.rotation);
            Instantiate(obstacle, transform.position + new Vector3(0.30f, -1.91f, randomZ), transform.rotation);
            Instantiate(obstacle, transform.position + new Vector3(2.20f, -1.91f, randomZ), transform.rotation);

            if (canDeployPickpus == 0)
            {
                Pickup_location = Random.Range(0, 3);
                if(Pickup_location == 0)
                    Instantiate(Pickup, transform.position + new Vector3(-1.60f, -1.91f, randomZ - 3 * obstacle.transform.position.z), Pickup.transform.rotation);
                else if(Pickup_location == 1)
                    Instantiate(Pickup, transform.position + new Vector3(0.30f, -1.91f, randomZ - 3 * obstacle.transform.position.z), Pickup.transform.rotation);
                else if(Pickup_location == 2)
                    Instantiate(Pickup, transform.position + new Vector3(2.20f, -1.91f, randomZ - 3 * obstacle.transform.position.z), Pickup.transform.rotation);
                canDeployPickpus = 10;
                next_is_empty = 1;
            }
            else
            {
                if (canDeployJetPack_Pickup == 0)
                {
                    JetPack_location = Random.Range(0, 3);

                    if (JetPack_location == 0)
                        Instantiate(JetPack_Pickup, transform.position + new Vector3(-1.60f, -1.91f, randomZ - 3 * obstacle.transform.position.z), Pickup.transform.rotation);
                    else if (JetPack_location == 1)
                        Instantiate(JetPack_Pickup, transform.position + new Vector3(0.30f, -1.91f, randomZ - 3 * obstacle.transform.position.z), Pickup.transform.rotation);
                    else if (JetPack_location == 2)
                        Instantiate(JetPack_Pickup, transform.position + new Vector3(2.20f, -1.91f, randomZ - 3 * obstacle.transform.position.z), Pickup.transform.rotation);
                    canDeployJetPack_Pickup = 20;
                }
                else
                {
                    if(canDeploySloMo_Pickup == 0)
                    {
                        SloMo_location = Random.Range(0, 3);
                        if (SloMo_location == 0)
                            Instantiate(SloMo_Pickup, transform.position + new Vector3(-1.60f, -1.91f, randomZ - 3 * obstacle.transform.position.z), Pickup.transform.rotation);
                        else if (SloMo_location == 1)
                            Instantiate(SloMo_Pickup, transform.position + new Vector3(0.30f, -1.91f, randomZ - 3 * obstacle.transform.position.z), Pickup.transform.rotation);
                        else if (SloMo_location == 2)
                            Instantiate(SloMo_Pickup, transform.position + new Vector3(2.20f, -1.91f, randomZ - 3 * obstacle.transform.position.z), Pickup.transform.rotation);
                        canDeploySloMo_Pickup = 30;
                    }
                    else
                    {
                        canDeploySloMo_Pickup--;
                    }
                    
                    canDeployJetPack_Pickup--;
                }

                canDeployPickpus--;
            }
        }
        else if (spawn_type == 2)
        {
            Instantiate(obstacle, transform.position + new Vector3(-1.60f, -1.91f, randomZ), transform.rotation);
            Instantiate(obstacle, transform.position + new Vector3(0.30f, -1.91f, randomZ), transform.rotation);

            if (canDeployPickpus == 0)
            {
                Pickup_location = Random.Range(0, 2);
                if (Pickup_location == 0)
                    Instantiate(Pickup, transform.position + new Vector3(-1.60f, -1.91f, randomZ - 3 * obstacle.transform.position.z), Pickup.transform.rotation);
                else if (Pickup_location == 1)
                    Instantiate(Pickup, transform.position + new Vector3(0.30f, -1.91f, randomZ - 3 * obstacle.transform.position.z), Pickup.transform.rotation);
                canDeployPickpus = 10;
                next_is_empty = 1;
            }
            else
            {
                if (canDeployJetPack_Pickup == 0)
                {
                    JetPack_location = Random.Range(0, 2);

                    if (JetPack_location == 0)
                        Instantiate(JetPack_Pickup, transform.position + new Vector3(-1.60f, -1.91f, randomZ - 3 * obstacle.transform.position.z), Pickup.transform.rotation);
                    else if (JetPack_location == 1)
                        Instantiate(JetPack_Pickup, transform.position + new Vector3(0.30f, -1.91f, randomZ - 3 * obstacle.transform.position.z), Pickup.transform.rotation);
                    canDeployJetPack_Pickup = 20;
                }
                else
                {
                    if (canDeploySloMo_Pickup == 0)
                    {
                        SloMo_location = Random.Range(0, 2);

                        if (JetPack_location == 0)
                            Instantiate(SloMo_Pickup, transform.position + new Vector3(-1.60f, -1.91f, randomZ - 3 * obstacle.transform.position.z), Pickup.transform.rotation);
                        else if (JetPack_location == 1)
                            Instantiate(SloMo_Pickup, transform.position + new Vector3(0.30f, -1.91f, randomZ - 3 * obstacle.transform.position.z), Pickup.transform.rotation);
                        canDeploySloMo_Pickup = 30;
                    }
                    else
                    {
                        canDeploySloMo_Pickup--;
                    }


                    canDeployJetPack_Pickup--;
                }



                canDeployPickpus--;
            }
        }
        else if (spawn_type == 3)
        {
            Instantiate(obstacle, transform.position + new Vector3(-1.60f, -1.91f, randomZ), transform.rotation);
            Instantiate(obstacle, transform.position + new Vector3(2.20f, -1.91f, randomZ), transform.rotation);

            if (canDeployPickpus == 0)
            {
                Pickup_location = Random.Range(0, 2);
                if (Pickup_location == 0)
                    Instantiate(Pickup, transform.position + new Vector3(-1.60f, -1.91f, randomZ - 3 * obstacle.transform.position.z), Pickup.transform.rotation);
                else if (Pickup_location == 1)
                    Instantiate(Pickup, transform.position + new Vector3(2.20f, -1.91f, randomZ - 3 * obstacle.transform.position.z), Pickup.transform.rotation);
                canDeployPickpus = 10;
                next_is_empty = 1;
            }
            else
            {
                if (canDeployJetPack_Pickup == 0)
                {
                    JetPack_location = Random.Range(0, 2);

                    if (JetPack_location == 0)
                        Instantiate(JetPack_Pickup, transform.position + new Vector3(-1.60f, -1.91f, randomZ - 3 * obstacle.transform.position.z), Pickup.transform.rotation);
                    else if (JetPack_location == 1)
                        Instantiate(JetPack_Pickup, transform.position + new Vector3(2.20f, -1.91f, randomZ - 3 * obstacle.transform.position.z), Pickup.transform.rotation);
                    canDeployJetPack_Pickup = 20;
                }
                else
                {
                    if (canDeploySloMo_Pickup == 0)
                    {
                        SloMo_location = Random.Range(0, 2);

                        if (SloMo_location == 0)
                            Instantiate(SloMo_Pickup, transform.position + new Vector3(-1.60f, -1.91f, randomZ - 3 * obstacle.transform.position.z), Pickup.transform.rotation);
                        else if (SloMo_location == 1)
                            Instantiate(SloMo_Pickup, transform.position + new Vector3(2.20f, -1.91f, randomZ - 3 * obstacle.transform.position.z), Pickup.transform.rotation);
                        canDeploySloMo_Pickup = 30;
                    }
                    else
                    {
                        canDeploySloMo_Pickup--;
                    }

                    canDeployJetPack_Pickup--;
                }


                canDeployPickpus--;
            }
        }
        else if (spawn_type == 4)
        {
            Instantiate(obstacle, transform.position + new Vector3(0.30f, -1.91f, randomZ), transform.rotation);
            Instantiate(obstacle, transform.position + new Vector3(2.20f, -1.91f, randomZ), transform.rotation);

            if (canDeployPickpus == 0)
            {
                Pickup_location = Random.Range(0, 2);
                if (Pickup_location == 0)
                    Instantiate(Pickup, transform.position + new Vector3(0.30f, -1.91f, randomZ - 3 * obstacle.transform.position.z), Pickup.transform.rotation);
                else if (Pickup_location == 1)
                    Instantiate(Pickup, transform.position + new Vector3(2.20f, -1.91f, randomZ - 3 * obstacle.transform.position.z), Pickup.transform.rotation);
                canDeployPickpus = 10;
                next_is_empty = 1;
            }
            else
            {
                if (canDeployJetPack_Pickup == 0)
                {
                    JetPack_location = Random.Range(0, 2);

                    if (JetPack_location == 0)
                        Instantiate(JetPack_Pickup, transform.position + new Vector3(-0.30f, -1.91f, randomZ - 3 * obstacle.transform.position.z), Pickup.transform.rotation);
                    else if (JetPack_location == 1)
                        Instantiate(JetPack_Pickup, transform.position + new Vector3(2.20f, -1.91f, randomZ - 3 * obstacle.transform.position.z), Pickup.transform.rotation);
                    canDeployJetPack_Pickup = 20;
                }
                else
                {
                    if (canDeploySloMo_Pickup == 0)
                    {
                        SloMo_location = Random.Range(0, 2);

                        if (JetPack_location == 0)
                            Instantiate(SloMo_Pickup, transform.position + new Vector3(-0.30f, -1.91f, randomZ - 3 * obstacle.transform.position.z), Pickup.transform.rotation);
                        else if (JetPack_location == 1)
                            Instantiate(SloMo_Pickup, transform.position + new Vector3(2.20f, -1.91f, randomZ - 3 * obstacle.transform.position.z), Pickup.transform.rotation);
                        canDeploySloMo_Pickup = 30;
                    }
                    else
                    {
                        canDeploySloMo_Pickup--;
                    }

                    canDeployJetPack_Pickup--;
                }



                canDeployPickpus--;
            }
        }
        else if (spawn_type == 5)
        {
            Instantiate(left_wall, new Vector3(-2.4f, -0.03f, 40), transform.rotation);
            Instantiate(right_wall, new Vector3(3.73f, -0.03f, 40), transform.rotation);
            //Debug.Log("Nothing");
            next_is_empty = 0;
        }
    }
}
