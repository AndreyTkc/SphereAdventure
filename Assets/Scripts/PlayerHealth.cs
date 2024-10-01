using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private static int _health = 5;

    public static void HealthUpdate()
    {
        _health--;
        
        Debug.Log(_health);
        
        if (_health <= 0)
        {
            Debug.Log("Game Over!");
        }
    }
}
