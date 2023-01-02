using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deeppanController : MonoBehaviour
{
    // Start is called before the first frame update
    public string cooking_food = "";
    public int cook_state = 0, anima = 0;
    [SerializeField] GameObject lid;
    [SerializeField] RectTransform UI;
    public void cooking(int _state)
    {
        if (_state == 1)
        {
            cook_state = _state;
            //鍋蓋出現，跑UI後cook_state = 2
            lid.active = true;
            UI.gameObject.active = true;
            anima = 1;
        }
        else if (_state == 2)
        {
            cooking_food = cooking_food + "soup";
        }
        else
        {
            //鍋蓋消失
            lid.active = false;
            cooking_food = "";
        }
    }
    private void Update()
    {
        if (anima == 1)
        {
            float HP = UI.sizeDelta.x, value = 0.001F;
            float currentHealth = HP - value;
            UI.sizeDelta = new Vector2(currentHealth,UI.sizeDelta.y);
            if (UI.sizeDelta.x <= 0)
            {
                UI.sizeDelta = new Vector2(1.5F, UI.sizeDelta.y);
                UI.gameObject.active = false;
                cook_state = 2;
                anima = 0;
            }
        }
    }
}
