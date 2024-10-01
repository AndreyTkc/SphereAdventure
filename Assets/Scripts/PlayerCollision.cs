using System.Collections;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    private Rigidbody _rb;
    private MeshRenderer _meshRenderer;
    private GameObject _go;
    private readonly Vector3 _spawnPoint = new Vector3(-7.75f, 14, -7.80000019f);
    public static bool IsEnabled = false;
    public static bool IsEnabledCameraMove = false;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _rb = GetComponent<Rigidbody>();
        GameObject faded = GameObject.Find("Faded");
        _go = faded;
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

            PlayerHealth.HealthUpdate();
            
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
        _go.SetActive(true);
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
        _rb.mass = 1;
        _rb.drag = 0;
        _rb.angularDrag = 0;
        transform.position = _spawnPoint;
        _meshRenderer.enabled = true;
        _rb.constraints = RigidbodyConstraints.None;
        _go.SetActive(false);
    }
    
}
