using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
//using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main_Menu : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Start_Button;
    public GameObject Shop_Button;
    public GameObject Quit_Button;
    public GameObject Back_Button;
    public GameObject Skin1;
    public GameObject Skin2;
    public GameObject Skin3;
    public GameObject Reset_Skin_Button;
    public GameObject Reset_Credits_Button;
    public GameObject Speaker_Button;
    public Text Game_Over_Text;
    public Text Score_Text;
    public Text Main_Button_Text;
    public Text Credits;
    public Text Skin1_Text;
    public Text Skin2_Text;
    public Text Skin3_Text;
    public Text Speaker_On_Off_Text;
    public static int Game_Sounds = 1;
    public static int Credits_number = 0;
    public static int Showing_Shop = 0;
    public static int game_Started = 0;
    public static int game_over_screen = 0;
    // Start is called before the first frame update
    void Start()
    {

        string stuff2;
        stuff2 = File.ReadAllText(Application.dataPath + "/credits.txt");
        Debug.Log(stuff2);

        Credits_number = Int32.Parse(stuff2);

        //Time.timeScale = 0;
        Game_Over_Text.gameObject.SetActive(false);
        Score_Text.gameObject.SetActive(false);
        Panel.gameObject.SetActive(true);
        Back_Button.gameObject.SetActive(false);
        Skin1.gameObject.SetActive(false);
        Skin2.gameObject.SetActive(false);
        Skin3.gameObject.SetActive(false);
        Reset_Skin_Button.gameObject.SetActive(false);
        Reset_Credits_Button.gameObject.SetActive(false);
        Credits.gameObject.SetActive(false);
        Skin1_Text.gameObject.SetActive(false);
        Skin2_Text.gameObject.SetActive(false);
        Skin3_Text.gameObject.SetActive(false);
        if (Game_Sounds == 1)
        {
            Speaker_On_Off_Text.text = "Sounds On";
        }
        else
        {
            Speaker_On_Off_Text.text = "Sounds Off";
        }
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(game_over_screen == 1 && Showing_Shop == 0)
        {
            Game_Over_Text.gameObject.SetActive(true);
            Score_Text.gameObject.SetActive(true);
            Score_Text.text = "Your score was " + PlayerController.score;
            Main_Button_Text.text = "Retry?";
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            //Time.timeScale = 1;
            game_Started = 1;
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void Start_The_Game()
    {
        //Time.timeScale = 1;
        game_Started = 1;
        PlayerController.score = 0;
        SceneManager.LoadScene("SampleScene");
    }

    public void Show_Shop()
    {
        if (Showing_Shop == 0)
        {
            Game_Over_Text.gameObject.SetActive(false);
            Score_Text.gameObject.SetActive(false);
            Start_Button.gameObject.SetActive(false);
            Quit_Button.gameObject.SetActive(false);
            Shop_Button.gameObject.SetActive(false);
            Back_Button.gameObject.SetActive(true);
            Skin1.gameObject.SetActive(true);
            Skin2.gameObject.SetActive(true);
            Skin3.gameObject.SetActive(true);
            Speaker_Button.gameObject.SetActive(false);
            Speaker_On_Off_Text.gameObject.SetActive(false);
            if (Credits_number < 1500)
            {
                Skin1.GetComponent<Button>().interactable = false;
            }
            if (Credits_number < 1500)
            {
                Skin2.GetComponent<Button>().interactable = false;
            }
            if (Credits_number < 5000)
            {
                Skin3.GetComponent<Button>().interactable = false;
            }
            Reset_Skin_Button.gameObject.SetActive(true);
            Reset_Credits_Button.gameObject.SetActive(true);
            Credits.text = "Credits: " + Credits_number;
            Credits.gameObject.SetActive(true);
            Skin1_Text.gameObject.SetActive(true);
            Skin2_Text.gameObject.SetActive(true);
            Skin3_Text.gameObject.SetActive(true);
            Showing_Shop = 1;
        }
        else
        {
            Game_Over_Text.gameObject.SetActive(true);
            Score_Text.gameObject.SetActive(true);
            Start_Button.gameObject.SetActive(true);
            Quit_Button.gameObject.SetActive(true);
            Shop_Button.gameObject.SetActive(true);
            Back_Button.gameObject.SetActive(false);
            Skin1.gameObject.SetActive(false);
            Skin2.gameObject.SetActive(false);
            Skin3.gameObject.SetActive(false);
            Reset_Skin_Button.gameObject.SetActive(false);
            Reset_Credits_Button.gameObject.SetActive(false);
            Credits.gameObject.SetActive(false);
            Skin1_Text.gameObject.SetActive(false);
            Skin2_Text.gameObject.SetActive(false);
            Skin3_Text.gameObject.SetActive(false);
            Speaker_Button.gameObject.SetActive(true);
            Speaker_On_Off_Text.gameObject.SetActive(true);
            Showing_Shop = 0;
        }
    }

    public void Item1()
    {
        PlayerController.Player_Skin = 1;
        Game_Over_Text.gameObject.SetActive(true);
        Score_Text.gameObject.SetActive(true);
        Start_Button.gameObject.SetActive(true);
        Quit_Button.gameObject.SetActive(true);
        Shop_Button.gameObject.SetActive(true);
        Back_Button.gameObject.SetActive(false);
        Skin1.gameObject.SetActive(false);
        Skin2.gameObject.SetActive(false);
        Skin3.gameObject.SetActive(false);
        Reset_Skin_Button.gameObject.SetActive(false);
        Reset_Credits_Button.gameObject.SetActive(false);
        Credits.gameObject.SetActive(false);
        Skin1_Text.gameObject.SetActive(false);
        Skin2_Text.gameObject.SetActive(false);
        Skin3_Text.gameObject.SetActive(false);
        Speaker_Button.gameObject.SetActive(true);
        Speaker_On_Off_Text.gameObject.SetActive(true);
        Skin1_Text.text = "You own this!";
        Showing_Shop = 0;
    }
    public void Item2()
    {
        PlayerController.Player_Skin = 2;
        Game_Over_Text.gameObject.SetActive(true);
        Score_Text.gameObject.SetActive(true);
        Start_Button.gameObject.SetActive(true);
        Quit_Button.gameObject.SetActive(true);
        Shop_Button.gameObject.SetActive(true);
        Back_Button.gameObject.SetActive(false);
        Skin1.gameObject.SetActive(false);
        Skin2.gameObject.SetActive(false);
        Skin3.gameObject.SetActive(false);
        Reset_Skin_Button.gameObject.SetActive(false);
        Reset_Credits_Button.gameObject.SetActive(false);
        Credits.gameObject.SetActive(false);
        Skin1_Text.gameObject.SetActive(false);
        Skin2_Text.gameObject.SetActive(false);
        Skin3_Text.gameObject.SetActive(false);
        Speaker_Button.gameObject.SetActive(true);
        Speaker_On_Off_Text.gameObject.SetActive(true);
        Skin2_Text.text = "You own this!";
        Showing_Shop = 0;
    }

    public void Item3()
    {
        PlayerController.Player_Skin = 3;
        Game_Over_Text.gameObject.SetActive(true);
        Score_Text.gameObject.SetActive(true);
        Start_Button.gameObject.SetActive(true);
        Quit_Button.gameObject.SetActive(true);
        Shop_Button.gameObject.SetActive(true);
        Back_Button.gameObject.SetActive(false);
        Skin1.gameObject.SetActive(false);
        Skin2.gameObject.SetActive(false);
        Skin3.gameObject.SetActive(false);
        Reset_Skin_Button.gameObject.SetActive(false);
        Reset_Credits_Button.gameObject.SetActive(false);
        Credits.gameObject.SetActive(false);
        Skin1_Text.gameObject.SetActive(false);
        Skin2_Text.gameObject.SetActive(false);
        Skin3_Text.gameObject.SetActive(false);
        Speaker_Button.gameObject.SetActive(true);
        Speaker_On_Off_Text.gameObject.SetActive(true);
        Skin2_Text.text = "You own this!";
        Showing_Shop = 0;
    }

    public void Reset_Skin()
    {
        PlayerController.Player_Skin = 0;
        Game_Over_Text.gameObject.SetActive(true);
        Score_Text.gameObject.SetActive(true);
        Start_Button.gameObject.SetActive(true);
        Quit_Button.gameObject.SetActive(true);
        Shop_Button.gameObject.SetActive(true);
        Back_Button.gameObject.SetActive(false);
        Skin1.gameObject.SetActive(false);
        Skin2.gameObject.SetActive(false);
        Skin3.gameObject.SetActive(false);
        Reset_Skin_Button.gameObject.SetActive(false);
        Reset_Credits_Button.gameObject.SetActive(false);
        Credits.gameObject.SetActive(false);
        Skin1_Text.gameObject.SetActive(false);
        Skin2_Text.gameObject.SetActive(false);
        Skin3_Text.gameObject.SetActive(false);
        Speaker_Button.gameObject.SetActive(true);
        Speaker_On_Off_Text.gameObject.SetActive(true);
        Showing_Shop = 0;
    }

    public void Reset_Credits()
    {
        Credits_number = 0;
        Game_Over_Text.gameObject.SetActive(true);
        Score_Text.gameObject.SetActive(true);
        Start_Button.gameObject.SetActive(true);
        Quit_Button.gameObject.SetActive(true);
        Shop_Button.gameObject.SetActive(true);
        Back_Button.gameObject.SetActive(false);
        Skin1.gameObject.SetActive(false);
        Skin2.gameObject.SetActive(false);
        Skin3.gameObject.SetActive(false);
        Reset_Skin_Button.gameObject.SetActive(false);
        Reset_Credits_Button.gameObject.SetActive(false);
        Credits.gameObject.SetActive(false);
        Skin1_Text.gameObject.SetActive(false);
        Skin2_Text.gameObject.SetActive(false);
        Skin3_Text.gameObject.SetActive(false);
        Speaker_Button.gameObject.SetActive(true);
        Speaker_On_Off_Text.gameObject.SetActive(true);
        Showing_Shop = 0;
    }

    public void Sounds_Controller()
    {
        if (Game_Sounds == 1)
        {
            Game_Sounds = 0;
            Speaker_On_Off_Text.text = "Sounds Off";
        }
        else
        {
            Game_Sounds = 1;
            Speaker_On_Off_Text.text = "Sounds On";
        }
    }

    public void Quit()
    {
        //EditorApplication.isPlaying = false;
        string stuff;
        stuff = "" + Credits_number;
        File.WriteAllText(Application.dataPath + "/credits.txt", stuff);
        Application.Quit();
    }
}
