using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menumanager : MonoBehaviour
{
    public static Menumanager Instance;

    [SerializeField] Menu[] menus;

    private void Awake()
    {
        Instance = this;
    }

    public void OpenMenu(string menuName)
    {
        for(int i = 0; i < menus.Length; i++)
        {
            if(menus[i].menuName == menuName)
            {
                menus[i].Open();
            }
            else if(menus[i].open == true)
            {
                CloseMenu(menus[i]);
            }
        }
    }
    public void OpenMenu(Menu menu)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].open == true)
            {
                CloseMenu(menus[i]);
            }
        }
        menu.Open();
    }
    public void CloseMenu(Menu menu)
    {
        menu.Close();
    }
}
