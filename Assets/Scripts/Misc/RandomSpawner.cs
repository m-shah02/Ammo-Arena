using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Vector3 center;
    public Vector3 size;
    public GameObject itemPrefab;
    public int maxObjects = 30; // Maximum number of objects that can be spawned
    private List<GameObject> spawnedObjects = new List<GameObject>();

    public float interval = 5f; // Interval in seconds
    private float nextTimeToSpawn = 0f;

    private void Start()
    {
        SpawnObject();
    }

    void Update()
    {
        if (Time.time >= nextTimeToSpawn && spawnedObjects.Count < maxObjects)
        {
            SpawnObject();
            nextTimeToSpawn = Time.time + interval;
        }
    }

    public void SpawnObject()
    {
        if (spawnedObjects.Count >= maxObjects)
        {
            Debug.LogWarning("Maximum number of objects reached. Cannot spawn more.");
            return;
        }

        Vector3 pos = center + new Vector3(
            Random.Range(-size.x / 2, size.x / 2),
            Random.Range(-size.y / 2, size.y / 2),
            Random.Range(-size.z / 2, size.z / 2));

        GameObject newItem = Instantiate(itemPrefab, pos, Quaternion.identity);
        spawnedObjects.Add(newItem);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}
