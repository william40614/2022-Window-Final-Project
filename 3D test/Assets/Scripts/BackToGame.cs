using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackToGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void ToGame()
    {
        SceneManager.LoadScene(1);
    }
}
