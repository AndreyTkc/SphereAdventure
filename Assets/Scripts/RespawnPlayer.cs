using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    [SerializeField] private GameObject go;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private MeshRenderer mr;
    private readonly Vector3 _spawnPoint = new Vector3(-7.75f, 14, -7.80000019f);
    
    
    public void Respawn()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.mass = 1;
        rb.drag = 0;
        rb.angularDrag = 0;
        go.transform.position = _spawnPoint;
        mr.enabled = true;
        rb.constraints = RigidbodyConstraints.None;
    }
}
