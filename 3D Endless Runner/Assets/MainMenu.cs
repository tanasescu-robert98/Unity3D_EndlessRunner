using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Panel;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        Panel.gameObject.SetActive(true);
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void Start_The_Game()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        EditorApplication.isPlaying = false;
    }
}
