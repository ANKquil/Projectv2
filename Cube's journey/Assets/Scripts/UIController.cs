using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    GameObject[] menuUI;
    GameObject[] gameUI;
    GameObject[] loseUI;

    public void OpenMenu()
    {
        foreach(GameObject element in menuUI)
        {
            element.SetActive(true);
        }
    }
    public void CloseMenu()
    {
        foreach (GameObject element in menuUI)
        {
            element.SetActive(false);
        }
    }
    public void OpenGame()
    {
        foreach (GameObject element in gameUI)
        {
            element.SetActive(true);
        }
    }
    public void CloseGame()
    {
        foreach (GameObject element in gameUI)
        {
            element.SetActive(false);
        }
    }
    public void OpenLose()
    {
        foreach (GameObject element in loseUI)
        {
            element.SetActive(true);
        }
    }
    public void CloseLose()
    {
        foreach (GameObject element in loseUI)
        {
            element.SetActive(false);
        }
    }
}
