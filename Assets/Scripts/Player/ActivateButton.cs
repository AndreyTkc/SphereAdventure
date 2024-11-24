using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class ActivateButton : MonoBehaviour
{
    [SerializeField] private GameObject buttonOne; 
    [SerializeField] private GameObject buttonTwo; 
    [SerializeField] private GameObject buttonThree;
    [SerializeField] private Material buttonOneColor;
    [SerializeField] private Material buttonTwoColor;
    [SerializeField] private Material buttonThreeColor;
    [SerializeField] private GameObject lockOne;
    [SerializeField] private GameObject lockTwo;
    [SerializeField] private GameObject lockThree;

    public void PushButton(string button)
    {
        switch (button)
        {
            case "Button1":
                AnimateButton(buttonOne, buttonOneColor, lockOne);
                break;
            case "Button2":
                AnimateButton(buttonTwo, buttonTwoColor, lockTwo);
                break;
            case "Button3":
                AnimateButton(buttonThree, buttonThreeColor, lockThree);
                break;
        }
    }

    private void AnimateButton(GameObject button, Material color, GameObject lockNumber)
    {
        button.transform.localScale = new Vector3(1.37051177f, 0.021364799f, 1.41144562f);
        button.GetComponent<Renderer>().material = color;
        lockNumber.SetActive(false);
    }
}
