using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyEnemy : MonoBehaviour
{
    public GameObject bullet;
    public GameObject FloatingText;
    public GameObject FloatingText_Jetpack;
    private GameObject newInstance;
    private float temps = 0;
    private float speed = 10000;
    public ParticleSystem expl;
    //public AudioSource awp_sound;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButton(0))
        {
            temps = Time.time;
        }
        if (Input.GetMouseButtonUp(0) && (Time.time - temps) < 0.2f)
        {
            // short Click
            if (Physics.Raycast(ray, out hit))
            {
                //if (hit.transform.name == "Cube")
                if (hit.transform.name.Contains("Enemy"))
                {

                    GameObject isbullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
                    Rigidbody isbulletRigid = isbullet.GetComponent<Rigidbody>();
                    //Vector3 directie = hit.point - transform.position;
                   
                    isbullet.transform.LookAt(hit.point);
                    isbulletRigid.AddForce(isbullet.transform.forward * speed);

                    //Debug.Log("SAKKKK");
                    Sound_Manager.awp_sound_enable = 1;
                    //if (MainMenu.Game_Sounds == 1)
                    //{
                        //awp_sound.volume = 0.25f;
                        //awp_sound.Play();
                    //}
                    Destroy(hit.transform.gameObject);
                    PlayerController.increase_score = 1;
                    Instantiate(expl, hit.transform.position, Quaternion.identity);
                    if(PlayerController.jetpack_higher == 0)
                        newInstance = Instantiate(FloatingText, new Vector3(hit.transform.position.x, hit.transform.position.y + 2.5f, hit.transform.position.z), Quaternion.identity);
                    else
                        newInstance = Instantiate(FloatingText_Jetpack, new Vector3(hit.transform.position.x, hit.transform.position.y + 2.5f, hit.transform.position.z), Quaternion.identity);
                }
            }
        }

        if (Input.GetMouseButtonUp(0) && (Time.time - temps) > 0.2f)
        {
            // Long Click
        }

        /*if (destroy_text_time > 0)
        {
            destroy_text_time++;
            if (destroy_text_time == 1000)
            {
                Destroy(newInstance);
                destroy_text_time = 0;
            }
        }*/
    }
}