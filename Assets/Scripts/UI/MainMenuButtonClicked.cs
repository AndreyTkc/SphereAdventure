using UnityEngine;

public class MainMenuButtonClicked : MonoBehaviour
{
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/FirstLevel");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
