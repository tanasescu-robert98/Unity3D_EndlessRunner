using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public GameObject FloatingText;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(this.gameObject);
            PlayerController.increase_score = 1;
            //Instantiate(FloatingText, new Vector3(Player.transform.position.x, Player.transform.position.y + 2, Player.transform.position.z), Quaternion.identity);
        }
    }
}
