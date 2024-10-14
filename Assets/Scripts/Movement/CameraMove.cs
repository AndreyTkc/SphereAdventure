using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 fixedRotation;
    [SerializeField] private float speedH = 2.0f;
    [SerializeField] private float speedV = 2.0f;

    private float _h = 0.0f;
    private float _v = 0.0f;

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
        
        _h += speedH * Input.GetAxis("Mouse X");
        _v -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(_h, _v, 0.0f);
        
        transform.position = new Vector3(player.transform.position.x + offset.x, transform.position.y, player.transform.position.z + offset.z);
        transform.rotation = Quaternion.Euler(fixedRotation);
    }
}