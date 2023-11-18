using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject[] _menus;
    [SerializeField] GameObject _closeMenuBtn;

    void Start()
    {
        LoadMenu(-1);
    }

    /// <summary>
    /// Similar usage to SceneManager.LoadScene 
    /// </summary>
    /// <param name="index">-1 if turn off all</param>
    public void LoadMenu(int index)
    {
        _closeMenuBtn.SetActive(index != -1);

        for (int i = 0; i < _menus.Length; i++)
        {
            _menus[i].SetActive(i == index);
        }
    }
}
