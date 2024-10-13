using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private void GoToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/StartMenu");
    }
}
