using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemies : MonoBehaviour
{
    public float speed;
    private float contor = 0;
    private int OK = 0;
    private int goLeft = 0;
    private int goRight = 1;
    private float initialx;
    // Start is called before the first frame update
    void Start()
    {
        initialx = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >= initialx + 20)
        {
            goLeft = 1;
            goRight = 0;
        }
        if(transform.position.x <= initialx - 20)
        {
            goLeft = 0;
            goRight = 1;
        }
        if (goRight == 1)
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z - speed * Time.deltaTime);
            contor++;
        }
        if (goLeft == 1)
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z - speed * Time.deltaTime);
            contor--;
        }





        /*if (contor == 1000)
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
        }*/
    }
}
