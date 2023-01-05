using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//control music with button

public class music_game : MonoBehaviour
{
    
    public AudioSource audioSource;
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        //add a listener for the button's onclick event
        button.onClick.AddListener(ToggleMusic);
        if(audioSource.isPlaying) Debug.Log("playing music");
    }

    // Update is called once per frame
    public void ToggleMusic()
    {
        if (audioSource.isPlaying)
        {
          
            audioSource.Stop();
        }
        else
        {
            audioSource.Play();
        }
       //audioSource.isPlaying = !audioSource.isPlaying;
    }
}
