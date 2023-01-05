using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deeppanController : MonoBehaviour
{
    // Start is called before the first frame update
    public string cooking_food = "";
    public int cook_state = 0, anima = 0;
    PhotonView PV;
    [SerializeField] GameObject lid;
    [SerializeField] RectTransform UI;
    public void cooking(int _state)
    {
        //if (anima == 1)
        //    return;
        PV = GetComponent<PhotonView>();
        if (!PV.IsMine)
            return;
        if (_state == 1 )
        {
            cook_state = _state;
            //鍋蓋出現，跑UI後cook_state = 2
            lid.active = true;
            UI.gameObject.active = true;
            anima = 1;
        }
        else if (_state == 2)
        {
            if (cooking_food == "Apple")
                cooking_food = "PW_orangejuice";
            else if (cooking_food == "Lemon")
                cooking_food = "PW_lemonade";
            else if (cooking_food == "WaterMElon")
                cooking_food = "PW_tea_cup01";
        }
        else if(_state == 0)
        {
            //鍋蓋消失
            lid.active = false;
            cooking_food = "";
        }
    }
    private void Update()
    {
        PV = GetComponent<PhotonView>();
        if (!PV.IsMine)
            return;
        //UI.parent.gameObject.active = false;
        if (anima == 1)
        {
            UI.parent.gameObject.active = true;
            float HP = UI.sizeDelta.x, value = 0.001F;
            float currentHealth = HP - value;
            UI.sizeDelta = new Vector2(currentHealth,UI.sizeDelta.y);
            if (UI.sizeDelta.x <= 0)
            {
                UI.sizeDelta = new Vector2(1.5F, UI.sizeDelta.y);
                UI.gameObject.active = false;
                cook_state = 2;
                cooking(2);
                anima = 0;
            }
        }
    }
}
