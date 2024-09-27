using UnityEngine;

public class StartButtonClicked : MonoBehaviour
{
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/FirstLevel");
    }
}
