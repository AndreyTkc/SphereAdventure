using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody _rb;
    
    [SerializeField] private float speed;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        if (!PlayerCollision.IsEnabled) return;
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        _rb.AddForce(new Vector3(x, 0, z) * (speed * Time.fixedDeltaTime), ForceMode.VelocityChange);
    }
}
