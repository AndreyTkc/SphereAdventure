using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSettings : MonoBehaviour
{
    public bool[] completedLevels;
    [SerializeField] private GameObject[] levelIcons;
    [SerializeField] private GameObject[] iconsTextLabels;

    private void Awake()
    {
        for (int i = 0; i < completedLevels.Length; i++)
        {
            completedLevels[i] = false; // temp
        }

        for (int k = 0; k < completedLevels.Length; k++)
        {
            if (completedLevels[k])
            {
                levelIcons[k].GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, 0.55f);
                iconsTextLabels[k].GetComponent<TextMeshProUGUI>().colorGradient = new VertexGradient(Color.white);
                iconsTextLabels[k].GetComponent<TextMeshProUGUI>().color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
            }
        }

    }

    public void setCompletedLevel(int level)
    {
        completedLevels[level - 1] = true;
    }   
}
