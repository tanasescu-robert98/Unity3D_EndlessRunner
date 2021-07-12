using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingJetPackEnemies : MonoBehaviour
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

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);
    }
}
