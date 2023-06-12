using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject[] menus;
    public static MenuManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void OpenMenu(string menuName)
    {
        foreach (var item in menus)
        {
            item.SetActive(false);
        }

        foreach (var item in menus)
        {
            if (item.name == menuName)
            {
                item.SetActive(true);
                break;
            }
        }
    }
}
