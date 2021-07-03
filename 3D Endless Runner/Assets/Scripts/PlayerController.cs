using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text score_display;
    public GameObject Panel;
    public GameObject game_paused_text;
    public static int increase_score = 0;
    public static float score = 0;
    public float playerSpeed;
    private int jump_time = 0;
    private int is_jumping = 0;
    private Rigidbody rb;
    private Vector3 playerDirection;
    private int contor = 0;
    private int reenable_contor = 0;
    private int enable_jumping = 0;
    private bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Panel.gameObject.SetActive(false);
        game_paused_text.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //print(playerDirection.y);
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(isPaused)
            {
                Time.timeScale = 1;
                isPaused = false;
                Panel.gameObject.SetActive(false);
                game_paused_text.gameObject.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                isPaused = true;
                Panel.gameObject.SetActive(true);
                game_paused_text.gameObject.SetActive(true);
            }
        }
        if (GameObject.Find("Player").transform.position.y < -2)
        {
            Debug.Log("GAME OVER!");
            score = 0;
            SceneManager.LoadScene("SampleScene");
        }
        if (increase_score == 1)
        {
            score = score + 10;
            score_display.text = "" + score;
            increase_score = 0;
        }
        if(reenable_contor <= 300 && reenable_contor != 0)
        {
            reenable_contor++;
            if (reenable_contor == 300)
                reenable_contor = 0;
        }
        if (Input.GetKeyDown("space") && reenable_contor == 0 && enable_jumping == 1)
        {

            enable_jumping = 0;
            is_jumping = 1;
        }
        if(is_jumping == 1)
        {
            playerDirection = new Vector3(0, jump_time * 10, 0).normalized;
            if(jump_time != 150)
            {
                jump_time++;
                contor++;
                playerDirection = new Vector3(0, jump_time , 0).normalized;
            }
            else
            {
                jump_time = 0;
                is_jumping = 0;
                reenable_contor = 1;
            }
        }
        if (playerDirection.x > -3 && playerDirection.x < 3 && is_jumping != 1)
        {
            float directionX = Input.GetAxisRaw("Horizontal");
            //float directionY = Input.GetAxisRaw("Vertical");
            playerDirection = new Vector3(directionX, 0, 0).normalized;
        }
        
    }
    void FixedUpdate()
    {
        if (playerDirection.x > -3 && playerDirection.x < 3 && is_jumping != 1)
        {
            rb.velocity = new Vector3(playerDirection.x * playerSpeed * 1.25f, -4.5f, 0);
        }
        if(is_jumping == 1)
        {
            rb.velocity = new Vector3(playerDirection.x * playerSpeed * 1.25f, playerDirection.y * playerSpeed * 2 , 0);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Platform")
        {
            enable_jumping = 1;
        }
    }
}
