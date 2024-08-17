using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : MonoBehaviour
{
    public List<GameObject> objectsToSpawn;
    public Transform spawnPoint;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnRandomObject();
        }
    }

    void SpawnRandomObject()
    {
        if (objectsToSpawn.Count == 0)
        {
            Debug.LogWarning("No objects to spawn!");
            return;
        }

        if (spawnPoint == null)
        {
            Debug.LogWarning("No spawn point set!");
            return;
        }

        int randomIndex = Random.Range(0, objectsToSpawn.Count);

        GameObject selectedObject = objectsToSpawn[randomIndex];

        Instantiate(selectedObject, spawnPoint.position, spawnPoint.rotation);
    }
}
