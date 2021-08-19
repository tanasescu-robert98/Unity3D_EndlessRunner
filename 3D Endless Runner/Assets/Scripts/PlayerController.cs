using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static int Player_Skin = 0;
    public Text score_display;
    public Text Notification;
    public GameObject Show_Skins_Button;
    public GameObject Panel;
    public GameObject Notification_Panel;
    public GameObject game_paused_text;
    public GameObject Jetpack_Tube;
    public GameObject Jetpack_Tube_2;
    public GameObject Left_Border;
    public GameObject Right_Border;
    public GameObject Skin1;
    public GameObject Skin2;
    public GameObject Skin3;
    public GameObject Default_Skin;
    public Material Default_Player;
    public Material Green_Player;
    public Material Red_Player;
    public Material Bling_Bling_Player;
    public ParticleSystem jump_effect;
    public ParticleSystem jetpack_effect;
    public HealthBar healthBar;
    public SloMoBar slomoBar;
    public int maxFuel = 10000;
    public float fuel = 10000;
    //public static Material originalMat;
    public static int jetpack_higher = 0;
    public static float jetpack_contor = 0;
    public static int doublejump_enabled = 0;
    public static int jetpack_enabled = 0;
    public static int isPlayerLow = 0;
    public static int increase_score = 0;
    public static int score = 0;
    public float playerSpeed;
    private int jump_time = 0;
    private int is_jumping = 0;
    private Rigidbody rb;
    private Vector3 playerDirection;
    private int contor = 0;
    private int reenable_contor = 0;
    private int enable_jumping = 0;
    private bool isPaused = false;
    public static int SlowMo_Activated = 0;
    public static int SlowMo_Contor = 0;
    public static int Pickup_sound_enable = 0;
    public GameObject Jetpack_Pickup_Text;
    private GameObject newinstance2;
    public static int pickup_picked = 0;
    public static int jetpack_pickup_contor = 0;
    public int SloMo_Max_Value = 5000;
    public int SloMo_value = 5000;
    public bool is_wallrunning_left = false;
    public bool is_wallrunning_right = false;
    public bool is_positioned = false;
    public bool is_wallrunning_up = false;
    public bool is_wallrunning_down = false;
    private int disable_gravity = 0;
    private float y_speed_gravity = 4.5f;

    // Start is called before the first frame update
    void Start()
    {
        newinstance2 = Instantiate(Jetpack_Pickup_Text, new Vector3(-100,-100,-100), Quaternion.identity);
        Instantiate(Jetpack_Tube, new Vector3(-100, -100, -100), Quaternion.identity);
        Instantiate(Jetpack_Tube_2, new Vector3(-100, -100, -100), Quaternion.identity);
        Instantiate(jetpack_effect, new Vector3(-100, -100, -100), Quaternion.identity);
        rb = GetComponent<Rigidbody>();
        Panel.gameObject.SetActive(false);
        Notification_Panel.gameObject.SetActive(false);
        game_paused_text.gameObject.SetActive(false);
        Show_Skins_Button.gameObject.SetActive(false);
        Skin1.gameObject.SetActive(false);
        Skin2.gameObject.SetActive(false);
        Skin3.gameObject.SetActive(false);
        Default_Skin.gameObject.SetActive(false);
        healthBar.SetMaxHealth(maxFuel);
        slomoBar.SetMaxSloMo(SloMo_Max_Value);
        slomoBar.gameObject.SetActive(false);
        healthBar.gameObject.SetActive(false);
        Left_Border.gameObject.SetActive(false);
        Right_Border.gameObject.SetActive(false);
        jetpack_higher = 0;
        if (Player_Skin == 0)
            this.GetComponent<MeshRenderer>().material = Default_Player;
        if (Player_Skin == 1)
            this.GetComponent<MeshRenderer>().material = Green_Player;
        if (Player_Skin == 2)
            this.GetComponent<MeshRenderer>().material = Red_Player;
        if (Player_Skin == 3)
            this.GetComponent<MeshRenderer>().material = Bling_Bling_Player;

        is_wallrunning_left = false;
        is_wallrunning_right = false;
        is_positioned = false;
        is_wallrunning_up = false;
        is_wallrunning_down = false;
        this.GetComponent<Rigidbody>().useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(is_wallrunning_left == true)
        {
            rb.velocity = new Vector3(0, 0, 0);
            if(is_positioned == false)
            {
                transform.position = new Vector3(-1.12f, -0.10f, 0.68f);
                transform.Rotate(0, 0, -14);
                is_wallrunning_up = true;
            }
            if(transform.position.y > 0.4f)
            {
                is_wallrunning_up = false;
                is_wallrunning_down = true;
            }
            if(transform.position.y < -0.40f)
            {
                is_wallrunning_up = true;
                is_wallrunning_down = false;
            }
            if(is_wallrunning_up == true)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.0025f, transform.position.z);
            }
            else if(is_wallrunning_down == true)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.0025f, transform.position.z);
            }
            is_positioned = true;
        }

        if(is_wallrunning_right == true)
        {
            rb.velocity = new Vector3(0, 0, 0);
            if(is_positioned == false)
            {
                transform.position = new Vector3(2.9f, -0.10f, 0.68f);
                transform.Rotate(0, 0, 14);
                is_wallrunning_up = true;
            }
            if(transform.position.y > 0.4f)
            {
                is_wallrunning_up = false;
                is_wallrunning_down = true;
            }
            if(transform.position.y < -0.40f)
            {
                is_wallrunning_up = true;
                is_wallrunning_down = false;
            }
            if(is_wallrunning_up == true)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.0025f, transform.position.z);
            }
            else if(is_wallrunning_down == true)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.0025f, transform.position.z);
            }
            is_positioned = true;
        }

        if(pickup_picked == 1)
        {
            if(jetpack_pickup_contor == 0)
                newinstance2.transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
            if (jetpack_pickup_contor == 200)
            {
                newinstance2.transform.position = new Vector3(-100, -100, -100);
                jetpack_pickup_contor = 0;
                pickup_picked = 0;
            }
            else
            {
                jetpack_pickup_contor++;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("N APASAT");
            disable_gravity = 1;
            y_speed_gravity = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(jetpack_enabled == 1)
            {
                this.transform.position = new Vector3(transform.position.x, 10, transform.position.z);
                jetpack_higher = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            Time.timeScale = 1.5f;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
        }

        if (SlowMo_Activated == 1)
        {
            Notification.text = "SlowMo Activated!";
            Notification_Panel.gameObject.SetActive(true);
            slomoBar.gameObject.SetActive(true);
            Time.timeScale = 0.3f;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
            SloMo_value--;
            slomoBar.SetSloMo(SloMo_value);
            SlowMo_Contor++;
            
        }
        if (SlowMo_Contor >= 5000)
        {
            slomoBar.gameObject.SetActive(false);
            Notification_Panel.gameObject.SetActive(false);
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02F;
            SlowMo_Activated = 0;
            SlowMo_Contor = 0;
            SloMo_value = 5000;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (jetpack_enabled == 0)
                jetpack_enabled = 0;
            else
            {
                Left_Border.gameObject.SetActive(false);
                Right_Border.gameObject.SetActive(false);
                maxFuel = 10000;
                fuel = 10000;
                jetpack_contor = 0;
                jetpack_enabled = 0;
                Jetpack_Tube.transform.position = new Vector3(-100, -100, -100);
                Jetpack_Tube_2.transform.position = new Vector3(-100, -100, -100);
                jetpack_effect.transform.position = new Vector3(-100, -100, -100);
                healthBar.gameObject.SetActive(false);
                Notification_Panel.gameObject.SetActive(false);
                jetpack_higher = 0;
            }
        }
        if (jetpack_enabled == 1)
        {
            Left_Border.gameObject.SetActive(true);
            Right_Border.gameObject.SetActive(true);
            healthBar.gameObject.SetActive(true);

            Notification.text = "Jetpack Activated!";
            Notification_Panel.gameObject.SetActive(true);
            if (jetpack_contor == 0)
            {
                this.transform.position = new Vector3(transform.position.x, 3.5f, transform.position.z);
                rb.useGravity = false;
            }
            float directionX = Input.GetAxisRaw("Horizontal");
            playerDirection = new Vector3(directionX, 0, 0).normalized;
            rb.velocity = new Vector3(playerDirection.x * playerSpeed * 1.25f, 0, 0);
            Jetpack_Tube.transform.position = new Vector3(transform.position.x - 0.214f, transform.position.y, transform.position.z - 0.35f);
            Jetpack_Tube_2.transform.position = new Vector3(transform.position.x + 0.203f, transform.position.y, transform.position.z - 0.35f);
            jetpack_effect.transform.position = new Vector3(transform.position.x - 0.007f, transform.position.y - 0.348f, transform.position.z - 0.64f);
            if (SlowMo_Activated == 0)
            {
                jetpack_contor++;
                fuel--;
            }
            else
            {
                jetpack_contor += 0.5f;
                fuel -= 0.5f;

            }
            healthBar.SetHealth(fuel);
            if(jetpack_contor >= 10000)
            {
                Left_Border.gameObject.SetActive(false);
                Right_Border.gameObject.SetActive(false);
                maxFuel = 10000;
                fuel = 10000;
                jetpack_contor = 0;
                jetpack_enabled = 0;
                Jetpack_Tube.transform.position = new Vector3(-100,-100,-100);
                Jetpack_Tube_2.transform.position = new Vector3(-100,-100,-100);
                jetpack_effect.transform.position = new Vector3(-100,-100,-100);
                healthBar.gameObject.SetActive(false);
                Notification_Panel.gameObject.SetActive(false);
                jetpack_higher = 0;
            }
        }
        if (doublejump_enabled == 2)
        {
            Notification.text = "Double Jump Activated!";
            Notification_Panel.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(isPaused)
            {
                if (Player_Skin == 0)
                    this.GetComponent<MeshRenderer>().material = Default_Player;
                if (Player_Skin == 1)
                    this.GetComponent<MeshRenderer>().material = Green_Player;
                if (Player_Skin == 2)
                    this.GetComponent<MeshRenderer>().material = Red_Player;
                Time.timeScale = 1;
                isPaused = false;
                Panel.gameObject.SetActive(false);
                game_paused_text.gameObject.SetActive(false);
                Show_Skins_Button.gameObject.SetActive(false);
                Cursor.visible = false;
            }
            else
            {
                Time.timeScale = 0;
                isPaused = true;
                Panel.gameObject.SetActive(true);
                game_paused_text.gameObject.SetActive(true);
                Show_Skins_Button.gameObject.SetActive(true);
                Cursor.visible = true;
            }
        }
        if (GameObject.Find("Player").transform.position.y < -2 && Main_Menu.game_Started == 1)
        {
            Main_Menu.Credits_number += score;
            string stuff;
            stuff = "" + Main_Menu.Credits_number;
            File.WriteAllText(Application.dataPath + "/credits.txt", stuff);
            Main_Menu.game_over_screen = 1;
            SceneManager.LoadScene("Main_Menu");
        }
        if (increase_score == 1)
        {
            if (jetpack_higher == 1 && pickup_picked == 0)
                score = score + 100;
            if (jetpack_higher == 1 && pickup_picked == 1)
            {
                score = score + 50;
            }
            if (jetpack_higher == 0)
                score = score + 10;
            score_display.text = "" + score;
            increase_score = 0;
        }
        if(Input.GetKeyDown("space") && (doublejump_enabled == 2 || doublejump_enabled == 1))
        {
            enable_jumping = 0;
            is_jumping = 1;
            doublejump_enabled--;
            if (doublejump_enabled == 0)
            {
                Instantiate(jump_effect, transform.position, Quaternion.identity);
                Notification_Panel.gameObject.SetActive(false);
            }
        }
        if (Input.GetKeyDown("space") && enable_jumping == 1 && doublejump_enabled == 0)
        {
            enable_jumping = 0;
            is_jumping = 1;
        }
        if(is_jumping == 1)
        {
            playerDirection = new Vector3(0, jump_time * 10, 0).normalized;
            if(transform.position.y < 3)
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
            playerDirection = new Vector3(directionX, 0, 0).normalized;
        }
        
    }
    void FixedUpdate()
    {
        if (playerDirection.x > -3 && playerDirection.x < 3 && is_jumping != 1 && jetpack_enabled == 0 && is_wallrunning_left == false && is_wallrunning_right == false)
        {
            rb.velocity = new Vector3(playerDirection.x * playerSpeed * 1.25f, -y_speed_gravity, 0);
        }
        if(is_jumping == 1 && jetpack_enabled == 0 && is_wallrunning_left == false && is_wallrunning_right == false)
        {
            rb.velocity = new Vector3(playerDirection.x * playerSpeed * 1.25f, playerDirection.y * playerSpeed * 2 , 0);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Left_Wall")
        {
            is_wallrunning_left = false;
            this.GetComponent<Rigidbody>().useGravity = true;
            transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            is_positioned = false;
            is_wallrunning_up = false;
            is_wallrunning_down = false;
        }
        if (collision.tag == "Right_Wall")
        {
            is_wallrunning_right = false;
            this.GetComponent<Rigidbody>().useGravity = true;
            transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            is_positioned = false;
            is_wallrunning_up = false;
            is_wallrunning_down = false;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Platform")
        {
            enable_jumping = 1;
        }
        if (collision.tag == "JetPack_Enemy")
        {
            maxFuel = 10000;
            fuel = 10000;
            jetpack_contor = 0;
            jetpack_enabled = 0;
            Jetpack_Tube.transform.position = new Vector3(-100, -100, -100);
            Jetpack_Tube_2.transform.position = new Vector3(-100, -100, -100);
            jetpack_effect.transform.position = new Vector3(-100, -100, -100);
            Notification_Panel.gameObject.SetActive(false);
            jetpack_higher = 0;


            Main_Menu.game_over_screen = 1;
            SceneManager.LoadScene("Main_Menu");
        }
        if (collision.tag == "Left_Wall")
        {
            is_wallrunning_left = true;
            this.GetComponent<Rigidbody>().useGravity = false;
        }
        if (collision.tag == "Right_Wall")
        {
            is_wallrunning_right = true;
            this.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    public void Show_Skins()
    {
        Show_Skins_Button.gameObject.SetActive(false);
        game_paused_text.gameObject.SetActive(false);
        Skin1.gameObject.SetActive(true);
        Skin2.gameObject.SetActive(true);
        Skin3.gameObject.SetActive(true);
        Default_Skin.gameObject.SetActive(true);
    }

    public void Set_Skin1()
    {
        Player_Skin = 1;
        Show_Skins_Button.gameObject.SetActive(false);
        Skin1.gameObject.SetActive(false);
        Skin2.gameObject.SetActive(false);
        Skin3.gameObject.SetActive(false);
        isPaused = false;
        if (Player_Skin == 0)
            this.GetComponent<MeshRenderer>().material = Default_Player;
        if (Player_Skin == 1)
            this.GetComponent<MeshRenderer>().material = Green_Player;
        if (Player_Skin == 2)
            this.GetComponent<MeshRenderer>().material = Red_Player;
        if (Player_Skin == 3)
            this.GetComponent<MeshRenderer>().material = Bling_Bling_Player;
        Time.timeScale = 1;
        isPaused = false;
        Panel.gameObject.SetActive(false);
        game_paused_text.gameObject.SetActive(false);
        Show_Skins_Button.gameObject.SetActive(false);
        Default_Skin.gameObject.SetActive(false);
        Cursor.visible = false;
    }

    public void Set_Skin2()
    {
        Player_Skin = 2;
        Show_Skins_Button.gameObject.SetActive(false);
        Skin1.gameObject.SetActive(false);
        Skin2.gameObject.SetActive(false);
        Skin3.gameObject.SetActive(false);
        isPaused = false;
        if (Player_Skin == 0)
            this.GetComponent<MeshRenderer>().material = Default_Player;
        if (Player_Skin == 1)
            this.GetComponent<MeshRenderer>().material = Green_Player;
        if (Player_Skin == 2)
            this.GetComponent<MeshRenderer>().material = Red_Player;
        if (Player_Skin == 3)
            this.GetComponent<MeshRenderer>().material = Bling_Bling_Player;
        Time.timeScale = 1;
        isPaused = false;
        Panel.gameObject.SetActive(false);
        game_paused_text.gameObject.SetActive(false);
        Show_Skins_Button.gameObject.SetActive(false);
        Default_Skin.gameObject.SetActive(false);
        Cursor.visible = false;
    }

    public void Set_Skin3()
    {
        Player_Skin = 3;
        Show_Skins_Button.gameObject.SetActive(false);
        Skin1.gameObject.SetActive(false);
        Skin2.gameObject.SetActive(false);
        Skin3.gameObject.SetActive(false);
        isPaused = false;
        if (Player_Skin == 0)
            this.GetComponent<MeshRenderer>().material = Default_Player;
        if (Player_Skin == 1)
            this.GetComponent<MeshRenderer>().material = Green_Player;
        if (Player_Skin == 2)
            this.GetComponent<MeshRenderer>().material = Red_Player;
        if (Player_Skin == 3)
            this.GetComponent<MeshRenderer>().material = Bling_Bling_Player;
        Time.timeScale = 1;
        isPaused = false;
        Panel.gameObject.SetActive(false);
        game_paused_text.gameObject.SetActive(false);
        Show_Skins_Button.gameObject.SetActive(false);
        Default_Skin.gameObject.SetActive(false);
        Cursor.visible = false;
    }

    public void Set_Default_Skin()
    {
        Player_Skin = 0;
        Show_Skins_Button.gameObject.SetActive(false);
        Skin1.gameObject.SetActive(false);
        Skin2.gameObject.SetActive(false);
        Skin3.gameObject.SetActive(false);
        isPaused = false;
        if (Player_Skin == 0)
            this.GetComponent<MeshRenderer>().material = Default_Player;
        if (Player_Skin == 1)
            this.GetComponent<MeshRenderer>().material = Green_Player;
        if (Player_Skin == 2)
            this.GetComponent<MeshRenderer>().material = Red_Player;
        if (Player_Skin == 3)
            this.GetComponent<MeshRenderer>().material = Bling_Bling_Player;
        Time.timeScale = 1;
        isPaused = false;
        Panel.gameObject.SetActive(false);
        game_paused_text.gameObject.SetActive(false);
        Show_Skins_Button.gameObject.SetActive(false);
        Default_Skin.gameObject.SetActive(false);
        Cursor.visible = false;
    }
}
