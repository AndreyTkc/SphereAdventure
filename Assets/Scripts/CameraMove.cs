using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 fixedRotation;

    private void Awake()
    {
        fixedRotation = transform.rotation.eulerAngles;        
    }
    
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        if (!player) return;
        transform.position = player.transform.position + offset;
        transform.rotation = Quaternion.Euler(fixedRotation);
    }
}