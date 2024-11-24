using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 specialOffset;
    [SerializeField] private Vector3 fixedRotation;

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
        if (!player || !PlayerCollision.IsEnabledCameraMove || !PlayerCollision.IsEnabled) return;
        
        transform.position = new Vector3(player.transform.position.x + offset.x, player.transform.position.y + specialOffset.y, player.transform.position.z + offset.z);
        transform.rotation = Quaternion.Euler(fixedRotation);
    }
    
    public void LowerCamera()
    {
        specialOffset.y -= 2.5f;
    }
    
    public void RaiseCamera()
    {
        specialOffset.y += 2.5f;
    }
    
    public void ResetCamera()
    {
        specialOffset.y = 6.500028f;
        transform.position = new Vector3(-7.75f,7.0f,-7.80000019f);
    }
}