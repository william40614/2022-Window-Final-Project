using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Debug.Log("quit");      //�D���x���quit
            Application.Quit(); //�������ε{��
        }
    }
}
