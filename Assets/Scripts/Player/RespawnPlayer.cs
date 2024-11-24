using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    [SerializeField] private GameObject go;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private MeshRenderer mr;
    [SerializeField] private CameraMove cameraMove;
    private readonly Vector3 _spawnPoint = new Vector3(-7.75f, 14, -7.80000019f);
    public static bool IsAlive = true;
    
    
    public void Respawn()
    {
        if (!IsAlive) return;
        
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.mass = 1;
        rb.drag = 0;
        rb.angularDrag = 0;
        go.transform.position = _spawnPoint;
        cameraMove.ResetCamera();
        mr.enabled = true;
        rb.constraints = RigidbodyConstraints.None;
    }
}
