using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevelMenu : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private static readonly int PlayFinish = Animator.StringToHash("PlayFinish");
    private GameDataManager.GameData _data = new GameDataManager.GameData();
    
    public void FinishFadeEffect()
    {
        animator.SetTrigger(PlayFinish);    
    }
    public void FinishMenu()
    {
        Debug.Log(_data.completedLevels);
        _data.completedLevels += 1;
        Debug.Log(_data.completedLevels);
        GameDataManager.Save(_data);
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartMenu");
    }
}
