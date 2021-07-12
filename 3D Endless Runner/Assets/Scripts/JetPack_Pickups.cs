using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack_Pickups : MonoBehaviour
{
    public GameObject FloatingText;
    public GameObject Player;
    private int goUp = 1;
    private int goDown = 0;
    //private GameObject newInstance2;
    //public float speed;
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
            /*newInstance2 = Instantiate(FloatingText, new Vector3(Player.transform.position.x,Player.transform.position.y + 2, Player.transform.position.z), Quaternion.identity);*/
            if (transform.name.Contains("SloMo"))
            {
                //PlayerController.pickup_picked = 1;
                //Sound_Manager.pickup_sound_enable = 1;
                Destroy(this.gameObject);
                PlayerController.SlowMo_Activated = 1;
                //PlayerController.increase_score = 1;
            }
            else
            {
                PlayerController.pickup_picked = 1;
                Sound_Manager.pickup_sound_enable = 1;
                Destroy(this.gameObject);
                PlayerController.increase_score = 1;
            }
            //PlayerController.doublejump_enabled = 2;
            //Instantiate(FloatingText, new Vector3(Player.transform.position.x, Player.transform.position.y + 2, Player.transform.position.z), Quaternion.identity);
        }
    }
}
