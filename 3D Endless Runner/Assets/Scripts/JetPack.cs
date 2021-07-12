using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack : MonoBehaviour
{
    public GameObject FloatingText;
    public GameObject Player;
    private int goUp = 1;
    private int goDown = 0;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (transform.position.y >= 0.2f)
        {
            goDown = 1;
            goUp = 0;
        }
        if (transform.position.y <= -0.6f)
        {
            goDown = 0;
            goUp = 1;
        }
        if (goDown == 1)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
        }
        if (goUp == 1)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(this.gameObject);
            PlayerController.jetpack_enabled = 1;
        }
    }
}
