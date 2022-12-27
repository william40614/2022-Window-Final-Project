using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;//Button
using UnityEngine;
using UnityEngine.SceneManagement;//SceneManager

public class btn_toGameScene : MonoBehaviour
{
   // public int sceneIndex;
    /*void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => {
            ClickEvent();
        });
    }*/

    // Update is called once per frame
   public void ClickEvent()
    {
        //switch the scene
        SceneManager.LoadScene(1);
    }
}
