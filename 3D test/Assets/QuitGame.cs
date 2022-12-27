using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Debug.Log("quit");      //主控台顯示quit
            Application.Quit(); //關閉應用程式
        }
    }
}
