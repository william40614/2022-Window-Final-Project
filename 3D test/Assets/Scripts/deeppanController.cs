using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deeppanController : MonoBehaviour
{
    // Start is called before the first frame update
    public string cooking_food = "";
    public int cook_state = 0;
    public void cooking(int _state)
    {
        if(_state == 1)
        {
            cook_state = _state;
            //鍋蓋出現，跑UI
        }
        else if(_state == 2)
        {
            cooking_food = cooking_food + "soup";
        }
        else
        {
            //鍋蓋消失
            cooking_food = "";
        }
    }
}
