using System.Collections;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private Animator animator;
    private Rigidbody _rb;
    private MeshRenderer _meshRenderer;
    [SerializeField] private PlayerHealth playerHealth;
    public static bool IsEnabled = false;
    public static bool IsEnabledCameraMove = false;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Ground")
        {
            _rb.mass = 10;
            _rb.drag = 1.5f;
            _rb.angularDrag = 1.5f;
            IsEnabled = true;
            IsEnabledCameraMove = true;
        }
        
        else if (collision.collider.CompareTag("Enemy") && gameObject && IsEnabled)
        {
            GameObject fractured = Instantiate(explosionPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            
            foreach (Rigidbody rb in fractured.GetComponentsInChildren<Rigidbody>())
            {
                Vector3 force = (rb.transform.position - transform.position).normalized;
                rb.AddForce(force);
            }

            playerHealth.HealthUpdate();
            
            StartCoroutine(Respawn());
        }
    }

    private IEnumerator Respawn()
    {
        _meshRenderer.enabled = false;
        IsEnabled = false;
        IsEnabledCameraMove = false;
        _rb.constraints = RigidbodyConstraints.FreezeAll;
        yield return new WaitForSeconds(2);
        if (RespawnPlayer.IsAlive)
        {
            animator.SetTrigger("Play");
        }
        IsEnabledCameraMove = true;
    }
}
