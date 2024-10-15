using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 fixedRotation;
    [SerializeField] private float speedH = 2.0f;
    [SerializeField] private float speedV = 2.0f;

    private void Awake()
    {
        fixedRotation = transform.rotation.eulerAngles;        
    }
    
    private void Start()
    {
        offset = transform.position - player.transform.position;
    }

    private void LateUpdate()
    {
        if (!player || !PlayerCollision.IsEnabledCameraMove) return;
        
        transform.position = new Vector3(player.transform.position.x + offset.x, transform.position.y, player.transform.position.z + offset.z);
        transform.rotation = Quaternion.Euler(fixedRotation);
    }
}