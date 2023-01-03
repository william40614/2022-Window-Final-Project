using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    [SerializeField] public Transform food;
    [SerializeField] public GameObject tomato;
    public int number_player = 0;
    // Start is called before the first frame update
    public void reAnimation(Animator pot)
    {
        //return to idle;
    }
    public GameObject newItemInstantiate(Transform player, string _string)
    {
        Debug.Log(_string);
        GameObject newItem;
        newItem = Instantiate(GameObject.Find(_string), player.position, new Quaternion(0, 0, 0, 0),food); 
        return newItem;
    }
}
