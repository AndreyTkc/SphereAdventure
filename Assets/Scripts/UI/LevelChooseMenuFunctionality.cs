using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class LevelChooseMenuFunctionality : MonoBehaviour
{
    public bool[] arrayOfCompletedLevels;
    [SerializeField] private GameObject[] levelIcons;
    [SerializeField] private GameObject[] iconsTextLabels;
    [SerializeField] private GameObject[] levelButtons;
    private GameDataManager.GameData _data = new GameDataManager.GameData();

    private void Awake()
    {
        GameDataManager.GameData loadedData = GameDataManager.Load();
        _data = loadedData;

        _data.completedLevels = loadedData.completedLevels;
        
        for (int i = 0; i < loadedData.completedLevels; i++)
        {
            arrayOfCompletedLevels[i] = true;
        }

        for (int k = 0; k < arrayOfCompletedLevels.Length; k++)
        {
            if (arrayOfCompletedLevels[k])
            {
                levelIcons[k].GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, 0.55f);
                iconsTextLabels[k].GetComponent<TextMeshProUGUI>().colorGradient = new VertexGradient(Color.white);
                iconsTextLabels[k].GetComponent<TextMeshProUGUI>().color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
                levelButtons[k].GetComponent<Button>().interactable = false;
            }
        }
    }
    
    public void PressLevelButton(GameObject button)
    {
        string parentName = button.transform.parent.name;
        char lastChar = parentName[^1];
        string levelName = "Level" + lastChar;
        Console.WriteLine(levelName);
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
    }
}
