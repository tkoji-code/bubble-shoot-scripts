using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    [SerializeField] GameObject bubblePrefab;
    [SerializeField] float timeBetweenSpawns = 3f;
    [SerializeField] float spawnBubbleSpeed = 100f;
    [SerializeField] bool looping = false;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnBubbles());
        }
        while (looping);
    }

    private IEnumerator SpawnBubbles()
    {
        var newBubble = Instantiate(bubblePrefab, transform.position, Quaternion.identity);
        newBubble.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -1f) * spawnBubbleSpeed * Time.deltaTime;
        yield return new WaitForSeconds(timeBetweenSpawns);
    }
}
