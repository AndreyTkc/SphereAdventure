using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private GameDataManager.GameData _data = new GameDataManager.GameData();
    private void Start()
    {
        _data = GameDataManager.Load();
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "Level1")
        {
            Spawn();
        }
    }
    
    private void Spawn()
    {
        rb.useGravity = true;
    }
    
    public void SpawnAfterCutscene()
    {
        rb.useGravity = true;
    }
}
