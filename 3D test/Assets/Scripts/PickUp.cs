using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] public GameSceneController gameSceneController;
    [SerializeField] public Transform food;
    [SerializeField] public Transform platform;
    [SerializeField] public GameObject pot1, pot2;
    float handlong = 100;
    Animator pot_animator;
    GameObject other_player;
    // Start is called before the first frame update
    public GameObject Finditems(Transform player)
    {
        GameObject pickup = null;
        float hand = handlong;
        bool pickup_isnull = true;
        if (player.name == "player1")
            other_player = GameObject.Find("PlayerAvatar(Clone)");
        else
            other_player = GameObject.Find("player1");
        Debug.Log(other_player.name);
        foreach (Transform item in food)
        {
            if(Vector3.Distance(player.position,item.position) < hand)
            {
                if (other_player.GetComponent<PlayerController>().dish_name == item.name)
                    continue;
                pickup = item.gameObject;
                pickup_isnull = false;
                hand = Vector3.Distance(player.position, item.position);
            }
        }/*
        if(pickup_isnull)
        {
            if (checkPot1CanPick(player))
            {
                pickup = Pickup_Pot1(player);
                pickup_isnull = false;
            }
            else if (checkPot2CanPick(player))
            {
                pickup = Pickup_Pot2(player);
                pickup_isnull = false;
            }
            Transform near_box = null;
            near_box = checkFoodBox(player);
            if (near_box != null && pickup_isnull)
            {
                pickup = pickup_foodbox(player,near_box);
                pickup_isnull = false;
            }
        }*/
        return pickup;
    }

    private bool checkPot1CanPick(Transform player)
    {
        if (Vector3.Distance(player.position,pot1.transform.position) < handlong)
        {
            if (pot1.GetComponent<deeppanController>().cook_state == 2)
            {
                return true;
            }
            else
            {
                //...
            }
        }
        return false;
    }
    private GameObject Pickup_Pot1(Transform player)
    {
        pot1.GetComponent<deeppanController>().cook_state = 0;
        return gameSceneController.newItemInstantiate(player,pot1.GetComponent<deeppanController>().cooking_food);
    }
    private bool checkPot2CanPick(Transform player)
    {
        if (Vector3.Distance(player.position, pot2.transform.position) < handlong)
        {
            if (pot2.GetComponent<deeppanController>().cook_state == 2)
            {
                return true;
            }
            else
            {
                //...
            }
        }
        return false;
    }
    private GameObject Pickup_Pot2(Transform player)
    {
        pot2.GetComponent<deeppanController>().cook_state = 0;
        return gameSceneController.newItemInstantiate(player, pot2.GetComponent<deeppanController>().cooking_food);
    }
    private Transform checkFoodBox(Transform player)
    {
        float min = handlong;
        Transform near_box = null ;
        foreach(Transform boxes in platform)
        {
            if (Vector3.Distance(player.position,boxes.position) < min)
            {
                min = Vector3.Distance(player.position, boxes.position);
                near_box = boxes;
            }
        }
        if (near_box != null)
            return near_box;
        return null;
    }
    private GameObject pickup_foodbox(Transform player,Transform near_box)
    {
        if(near_box.name == "tomato_box")
        {
            return gameSceneController.newItemInstantiate(player, "tomato");
        }
        return null;
    }
    public void putdown(Transform dish)
    {
        float hand = handlong;
        Transform placed = null;
        foreach (Transform item in platform)
        {
            if (Vector3.Distance(dish.position, item.position) < hand)
            {
                placed = item;
                hand = Vector3.Distance(dish.position, item.position);
            }
        }
        //¬Ý¯¸¦ì
        if (hand > 5)
            dish.position = new Vector3(transform.position.x, (float)(transform.position.y - 0.5), transform.position.z + 2);
        else
        {
            if(placed.gameObject == pot1)
            {
                pot1.GetComponent<deeppanController>().cooking_food = dish.name;
                pot1.GetComponent<deeppanController>().cooking(1);
            }
            else if(placed.gameObject == pot2)
            {
                pot2.GetComponent<deeppanController>().cooking_food = dish.name;
                pot2.GetComponent<deeppanController>().cooking(1);

            }
            else
            {
                dish.position = new Vector3(placed.position.x, placed.position.y + 1, placed.position.z);
            }
        }

    }
}
