using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private Animator animator;
    private Rigidbody _rb;
    private MeshRenderer _meshRenderer;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private PlayerAtFinish playerAtFinish;
    [SerializeField] private ActivateButton activateButton;
    [SerializeField] private AddHealth addHealth;
    [SerializeField] private CameraMove cameraMove;
    public static bool IsEnabled = false;
    public static bool IsEnabledCameraMove = false;
    private static readonly int Play = Animator.StringToHash("PlayRespawn");

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

            playerHealth.RemoveHealth();
            
            StartCoroutine(Respawn());
        }
        else if (collision.collider.name == "FinishCylinder" && gameObject && IsEnabled)
        {
            _rb.useGravity = false;
            playerAtFinish.isPulling = false;
        }
        
        else if (collision.collider.CompareTag("Button") && gameObject && IsEnabled)
        {
            activateButton.PushButton(collision.gameObject.name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().name == "FinishTrigger" && gameObject && IsEnabled)
        {
            playerAtFinish.FreezePlayer();  
        }
        else if (other.GetComponent<Collider>().CompareTag("Heal") && gameObject && IsEnabled)
        {
            addHealth.AddHealthToPlayer();
            other.gameObject.SetActive(false);
            var pointLight = other.transform.parent.GetComponentInChildren<Light>();
            if (pointLight != null && pointLight.type == LightType.Point)
            {
                pointLight.enabled = false;
            }
        }
        else if (other.GetComponent<Collider>().CompareTag("Trigger") && gameObject && IsEnabled)
        {
            cameraMove.LowerCamera();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>().CompareTag("Trigger") && gameObject && IsEnabled)
        {
            cameraMove.RaiseCamera();
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
            animator.SetTrigger(Play);
        }
        IsEnabledCameraMove = true;
    }
}
