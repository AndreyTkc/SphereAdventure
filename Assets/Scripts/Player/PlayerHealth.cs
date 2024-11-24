using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private static readonly int GameOverTrigger = Animator.StringToHash("GameOverTrigger");
    public int health = 5;
    public int healthPointsInInventory = 0;

    [SerializeField] private UpdateLives updateLives;
    [SerializeField] private Animator animator;

    private void HealthUpdate()
    {
        updateLives.UpdatePlayerLives(health);
        
        if (health <= 0)
        {
            animator.SetTrigger(GameOverTrigger);
            RespawnPlayer.IsAlive = false;
        }
    }
    
    public void AddHealth()
    {
        if (health >= 5)
        {
            healthPointsInInventory++;
            updateLives.ChangeLivesInInventory(healthPointsInInventory);
        }
        else
        {
            health++;
            HealthUpdate();
        }
    }

    public void RemoveHealth()
    {
        health--;
        HealthUpdate();
    }
}
