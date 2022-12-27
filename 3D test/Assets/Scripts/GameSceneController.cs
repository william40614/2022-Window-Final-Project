using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    [SerializeField] public Transform food;
    [SerializeField] public GameObject tomato;
    // Start is called before the first frame update
    public void reAnimation(Animator pot)
    {
        //return to idle;
    }
    public GameObject newItemInstantiate(Transform player, string _string)
    {
        GameObject newItem;
        newItem = Instantiate(tomato, player.position, new Quaternion(0, 0, 0, 0),food);
        return newItem;
    }
}
