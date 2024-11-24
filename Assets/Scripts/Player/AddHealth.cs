using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealth : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private UpdateLives updateLives;

    public void AddHealthToPlayer()
    {
        playerHealth.AddHealth();
    }
}
