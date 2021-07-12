using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public GameObject FloatingText;
    public GameObject Player;
    private int goUp = 1;
    private int goDown = 0;
    public float speed;
    //public AudioSource pickup_sound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if(transform.position.y >= 0.2f)
        {
            goDown = 1;
            goUp = 0;
        }
        if(transform.position.y <= -0.6f)
        {
            goDown = 0;
            goUp = 1;
        }
        if(goDown == 1)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
        }
        if(goUp == 1)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController.pickup_picked = 1;
            Sound_Manager.pickup_sound_enable = 1;
            /*if (MainMenu.Game_Sounds == 1)
            {
                pickup_sound.volume = 0.25f;
                pickup_sound.Play();
            }*/
            Destroy(this.gameObject);
            PlayerController.increase_score = 1;
            PlayerController.doublejump_enabled = 2;
            //Instantiate(FloatingText, new Vector3(Player.transform.position.x, Player.transform.position.y + 2, Player.transform.position.z), Quaternion.identity);
        }
    }
}
