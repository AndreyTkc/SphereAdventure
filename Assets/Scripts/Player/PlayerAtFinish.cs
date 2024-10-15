using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerAtFinish : MonoBehaviour
{
    private static readonly int Finish = Animator.StringToHash("Finish");
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject finishAnimation;
    [SerializeField] private Animator animator;
    [SerializeField] private new Camera camera;
    [SerializeField] private CinemachineSmoothPath dollyTrack;
    private Rigidbody _rb;
    public bool isPulling = false;

    private void Awake()
    {
        _rb = player.GetComponent<Rigidbody>();
    }
    
    public void FreezePlayer()
    {
        wall.SetActive(true);
        //PlayerCollision.IsEnabledCameraMove = false;
        StartCoroutine(Cutscene());
    }

    private IEnumerator Cutscene()
    {
        yield return new WaitForSeconds(1.5f);
        isPulling = true;
        PlayerCollision.IsEnabledCameraMove = false;
        PlayerCollision.IsEnabled = false;
        Vector3 localPosition = dollyTrack.transform.InverseTransformPoint(camera.transform.position);
        dollyTrack.m_Waypoints[0].position = localPosition;
        finishAnimation.SetActive(true);
        animator.SetTrigger(Finish);
    }

    private void FixedUpdate()
    {
        if (isPulling)
        {
            AttractPlayer();
        }
    }

    private void AttractPlayer()
    {
        _rb.AddForce(Vector3.up * 160); // Adjust the force value as needed
    }
}
