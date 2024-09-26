using System.Collections;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    private Rigidbody _rb;
    private MeshRenderer _meshRenderer;
    public static bool IsEnabled = false;

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
        }
        
        else if (collision.collider.CompareTag("Enemy") && gameObject)
        {
            GameObject fractured = Instantiate(explosionPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            
            foreach (Rigidbody rb in fractured.GetComponentsInChildren<Rigidbody>())
            {
                Vector3 force = (rb.transform.position - transform.position).normalized;
                rb.AddForce(force);
            }
            StartCoroutine(Respawn());
        }
    }

    private IEnumerator Respawn()
    {
        _meshRenderer.enabled = false;
        yield return new WaitForSeconds(2);
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
        _rb.mass = 1;
        _rb.drag = 0;
        _rb.angularDrag = 0;
        IsEnabled = false;
        transform.position = new Vector3(-7.75f, 14, -7.80000019f);
        _meshRenderer.enabled = true;
    }
    
}
