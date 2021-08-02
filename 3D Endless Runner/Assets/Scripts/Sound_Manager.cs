using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public static int pickup_sound_enable = 0;
    public static int awp_sound_enable = 0;
    public AudioSource pickup_sound;
    public AudioSource awp_sound;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pickup_sound_enable == 1 && Main_Menu.Game_Sounds == 1)
        {
            pickup_sound.volume = 0.25f;
            pickup_sound.Play();
            pickup_sound_enable = 0;
        }
        if (awp_sound_enable == 1 && Main_Menu.Game_Sounds == 1)
        {
            awp_sound.volume = 0.25f;
            awp_sound.Play();
            awp_sound_enable = 0;
        }
    }
}
