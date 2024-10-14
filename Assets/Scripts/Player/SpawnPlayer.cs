using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    
    public void Start()
    {
        rb.useGravity = true;
        Debug.Log("Player has spawned!");
    }
}
