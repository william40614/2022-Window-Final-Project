using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class aboutGame : MonoBehaviour
{

    public Button button;
    public Canvas canvas;
    void Start()
    {
        button.onClick.AddListener(OpenMenu);
    }

    public void OpenMenu()
    {
        if (canvas.enabled == false)
        {
            canvas.enabled = true;
        }
        else
        {
            canvas.enabled = false;
        }


       
    }
}
