using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndPlayButton : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject levelChooseMenu;
    
    public void BackToMainMenu()
    {
        mainMenu.SetActive(true);
        levelChooseMenu.SetActive(false);
    }
    
    public void GoToLevelChooseMenu()
    {
        mainMenu.SetActive(false);
        levelChooseMenu.SetActive(true);
    }
}
