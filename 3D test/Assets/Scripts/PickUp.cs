using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] public GameSceneController gameSceneController;
    [SerializeField] public Transform food;
    [SerializeField] public Transform platform;
    [SerializeField] public GameObject pot1, pot2;
    float handlong = 2;
    Animator pot_animator;
    GameObject other_player;
    // Start is called before the first frame update
    public GameObject Finditems(Transform player)
    {
        GameObject pickup = null;
        float hand = handlong;
        bool pickup_isnull = true;
        if (player.name == "player1")
            other_player = GameObject.Find("PlayerAvatarZ(Clone)");
        else
            other_player = GameObject.Find("player1");
        //Debug.Log(other_player.name);
        foreach (Transform item in food)
        {
            if (Vector3.Distance(player.position, item.position) < hand)
            {
                if (other_player!=null &&  other_player.GetComponent<PlayerController>().dish_name == item.name)
                    continue;
                pickup = item.gameObject;
                pickup_isnull = false;
                hand = Vector3.Distance(player.position, item.position);
            }
        }
        Debug.Log(hand);
            if (checkPot1CanPick(player) && hand > Vector3.Distance(pot1.transform.position, player.position))
            {
                pickup = Pickup_Pot1(player);
                pickup_isnull = false;
            }
           /* else if (checkPot2CanPick(player) && hand > Vector3.Distance(pot2.transform.position, player.position))
            {
                pickup = Pickup_Pot2(player);
                pickup_isnull = false;
            }*/
            Transform near_box = null;
            /*near_box = checkFoodBox(player);
            if (near_box != null && hand > Vector3.Distance(near_box.position, player.position))
            {
                pickup = pickup_foodbox(player, near_box);
                pickup_isnull = false;
            }*/
        return pickup;
    }

    private bool checkPot1CanPick(Transform player)
    {
        if (Vector3.Distance(player.position, pot1.transform.position) < handlong)
            if (pot1.GetComponent<deeppanController>().cook_state == 2)
                return true;
        return false;
    }
    private GameObject Pickup_Pot1(Transform player)
    {
        GameObject cooked_food =  gameSceneController.newItemInstantiate(player, pot1.GetComponent<deeppanController>().cooking_food);
        pot1.GetComponent<deeppanController>().cook_state = 0;
        pot1.GetComponent<deeppanController>().cooking(0);
        return cooked_food;
    }
    private bool checkPot2CanPick(Transform player)
    {
        if (Vector3.Distance(player.position, pot2.transform.position) < handlong)
            if (pot2.GetComponent<deeppanController>().cook_state == 2)
                return true;
        return false;
    }
    private GameObject Pickup_Pot2(Transform player)
    {
        pot2.GetComponent<deeppanController>().cook_state = 0;
        pot2.GetComponent<deeppanController>().cooking(0);
        return gameSceneController.newItemInstantiate(player, pot2.GetComponent<deeppanController>().cooking_food);
    }
    private Transform checkFoodBox(Transform player)
    {
        float min = 3;
        Transform near_box = null;
        foreach (Transform boxes in platform)
        {
            if (Vector3.Distance(player.position, boxes.position) < min)
            {
                min = Vector3.Distance(player.position, boxes.position);
                near_box = boxes;
            }
        }
        if (near_box != null)
            return near_box;
        return null;
    }
    private GameObject pickup_foodbox(Transform player, Transform near_box)
    {
        if (near_box.name == "tomato_box")
            return gameSceneController.newItemInstantiate(player, "tomato");
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
        if (hand >= handlong)
            dish.position = new Vector3(dish.position.x, (float)(dish.position.y - 0.5), dish.position.z);
        else
        {
            if (placed.gameObject == pot1)
            {
                pot1.GetComponent<deeppanController>().cooking_food = dish.name;
                pot1.GetComponent<deeppanController>().cooking(1);
                dish.transform.position = Vector3.zero;
            }
            else if (placed.gameObject == pot2)
            {
                pot2.GetComponent<deeppanController>().cooking_food = dish.name;
                pot2.GetComponent<deeppanController>().cooking(1);
                dish.transform.position = Vector3.zero;
            }
            else
                dish.position = new Vector3(placed.position.x, placed.position.y + (float)1.2, placed.position.z);
        }
        if (dish.name == "PW_lemonade")
        {
            if (placed !=null && (placed.gameObject.name == "table" || placed.gameObject.name == "table (1)" || placed.gameObject.name == "long_table"))
            {
                dish.position = Vector3.zero;
                GetComponent<GameSceneController>().sroceplus();
            }
        }
    }
}
