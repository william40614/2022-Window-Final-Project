using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music_menu : MonoBehaviour
{


    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        //play music when game is started
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
