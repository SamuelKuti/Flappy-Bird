using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPipes : MonoBehaviour
{

    [SerializeField] private GameObject topPipe;
    [SerializeField] private GameObject bottomPipe;
    [SerializeField] private float maxX;
    [SerializeField] private float minX;
    [SerializeField] private float maxYTop;
    [SerializeField] private float minYTop;
    [SerializeField] private float maxYBottom;
    [SerializeField] private float minYBottom;
    [SerializeField] private float timeBetweenSpawn;
    private float spawnTime;

    void Update()
    {
        if (Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    private void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomYTop = Random.Range(minYTop, maxYTop);
        float randomYBottom = Random.Range(minYBottom, maxYBottom);

        Instantiate(topPipe, transform.position + new Vector3(randomX, randomYTop, 0), transform.rotation);
        Instantiate(bottomPipe, transform.position + new Vector3(randomX, randomYBottom, 0), transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Side Border")
        {
            Destroy(this.gameObject);
        }
    }
}
