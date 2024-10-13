using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnObject;
    public float spawnChance;

    private float time;
    private bool triedToSpawn = false;

    // Update is called once per frame
    void Update()
    {
        if (!triedToSpawn)
        {  
            float chance = Random.Range(0.0f, 1.0f);

           // Object has chance to spawn
           if (chance <= spawnChance)
            {
                SpawnObject();
            }

            triedToSpawn = true;
        }
    }

    private void SpawnObject()
    {
        // Spawn object
        GameObject spawnedObj = Instantiate(spawnObject, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);

        // Get object scale
        Vector3 scale = spawnedObj.transform.localScale;

        // Set object parent to spawner's parent, keep original position, scale, and rotation
        spawnedObj.transform.SetParent(transform.parent, worldPositionStays: true);

        // Reset object scale
        spawnedObj.transform.localScale = scale;
    }
}
