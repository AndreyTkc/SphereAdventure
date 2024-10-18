using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevelMenu : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private static readonly int PlayFinish = Animator.StringToHash("PlayFinish");
    
    public void FinishFadeEffect()
    {
        animator.SetTrigger(PlayFinish);    
    }
    public void FinishMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartMenu");
    }
}
