using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesMovement : MonoBehaviour
{
    [SerializeField] private float waveSpeed = 1f;
    [SerializeField] private float waveHeight = 2f;
    [SerializeField] private float delayBetweenBlocks = 0.2f;
    
    private List<Transform> obstacleBlocks = new List<Transform>();
    private List<Vector3> originalPositions = new List<Vector3>();
    private bool isWaveActive = false;

    void Start()
    {
        foreach (Transform child in transform)
        {
            obstacleBlocks.Add(child);
            originalPositions.Add(child.position);
        }
        
        StartCoroutine(WaveAnimation());
    }

    IEnumerator WaveAnimation()
    {
        while (true)
        {
            yield return StartCoroutine(MoveBlocksUp());
            
            yield return new WaitForSeconds(1f);
            
            yield return StartCoroutine(MoveBlocksDown());
            
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator MoveBlocksUp()
    {
        for (int i = 0; i < obstacleBlocks.Count; i++)
        {
            StartCoroutine(MoveBlockUp(obstacleBlocks[i], originalPositions[i]));
            yield return new WaitForSeconds(delayBetweenBlocks);
        }
    }

    IEnumerator MoveBlocksDown()
    {
        for (int i = 0; i < obstacleBlocks.Count; i++)
        {
            StartCoroutine(MoveBlockDown(obstacleBlocks[i], originalPositions[i]));
            yield return new WaitForSeconds(delayBetweenBlocks);
        }
    }

    IEnumerator MoveBlockUp(Transform block, Vector3 originalPos)
    {
        Vector3 targetPos = originalPos + Vector3.up * waveHeight;
        float duration = 1f / waveSpeed;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            block.position = Vector3.Lerp(originalPos, targetPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        block.position = targetPos;
    }

    IEnumerator MoveBlockDown(Transform block, Vector3 originalPos)
    {
        Vector3 currentPos = block.position;
        float duration = 1f / waveSpeed;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            block.position = Vector3.Lerp(currentPos, originalPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        block.position = originalPos;
    }
}