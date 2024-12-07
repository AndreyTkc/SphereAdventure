using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevelMenu : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private static readonly int PlayFinish = Animator.StringToHash("PlayFinish");
    private GameDataManager.GameData _data;
    
    private void Awake()
    {
        _data = GameDataManager.Load();
        if (_data == null)
        {
            _data = new GameDataManager.GameData();
        }
    }
    
    public void FinishFadeEffect()
    {
        animator.SetTrigger(PlayFinish);    
    }
    public void FinishMenu()
    {
        _data.completedLevels += 1;
        GameDataManager.Save(_data);
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartMenu");
    }
}
