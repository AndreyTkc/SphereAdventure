using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonFunctionality : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject bar;
    [SerializeField] private GameObject pauseIcon;
    [SerializeField] private Button resumeButton;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject levelChooseMenu;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeSelf)
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            ShowBarAndPauseIcon();
        } else if (Input.GetKeyDown(KeyCode.Escape) && !pauseMenu.activeSelf)
        {
            Time.timeScale = 0;
            HideBarAndPauseIcon();
            pauseMenu.SetActive(true);
        }
    }

    public void PauseMenu()
    {
        Time.timeScale = 0;
        HideBarAndPauseIcon();
        pauseMenu.SetActive(true);
    }

    public void PlayGame()
    {
        startMenu.SetActive(false);
        levelChooseMenu.SetActive(true);
    }

    public void BackFromLevelMenuToMainMenu()
    {
        startMenu.SetActive(true);
        levelChooseMenu.SetActive(false);
    }
    
    public void StartMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartMenu");
    }
    
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        ShowBarAndPauseIcon();
        ResetButtonState(resumeButton);
        DeselectButton();
    }

    public void Options()
    {
        
    }
    
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game has been quit!");
    }

    private void HideBarAndPauseIcon()
    {
        bar.SetActive(false);
        pauseIcon.SetActive(false);
    }
    
    private void ShowBarAndPauseIcon()
    {
        bar.SetActive(true);
        pauseIcon.SetActive(true);
    }
    
    private void ResetButtonState(Button button)
    {
        Animator animator = button.GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetTrigger("Normal");
        }
    }
    
    private void DeselectButton()
    {
        eventSystem.SetSelectedGameObject(null);
    }
}
