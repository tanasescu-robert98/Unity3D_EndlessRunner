using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemies : MonoBehaviour
{
    public float speed;
    private float contor = 0;
    private int OK = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (contor == 1000)
            OK = 1;
        if (contor == 0)
            OK = 0;
        if (OK == 0)
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z - speed * Time.deltaTime);
            contor++;
        }
        if(OK == 1)
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z - speed * Time.deltaTime);
            contor--;
        }
    }
}
