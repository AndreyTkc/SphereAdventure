using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private static readonly int GameOverTrigger = Animator.StringToHash("GameOverTrigger");
    private int _health = 5;

    [SerializeField] private UpdateLives updateLives;
    [SerializeField] private Animator animator;

    public void HealthUpdate()
    {
        _health--;
        
        Debug.Log(_health);
        
        updateLives.UpdatePlayerLives(_health);
        
        if (_health <= 0)
        {
            Debug.Log("Game Over!");
            animator.SetTrigger(GameOverTrigger);
            RespawnPlayer.IsAlive = false;
        }
    }
}
