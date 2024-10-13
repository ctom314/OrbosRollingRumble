using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlyingSpawner : MonoBehaviour
{
    public GameObject spawnObject;
    public float spawnChance;

    private float time;
    private int startDirection;
    private bool triedToSpawn = false;

    // Update is called once per frame
    void Update()
    {
        if (!triedToSpawn)
        {
            float chance = Random.Range(0.0f, 1.0f);

            // Randomize starting direction (up, down)
            startDirection = Random.Range(1, 3);

            // Spawn chance
            if (chance <= spawnChance)
            {
                setDirection();
                SpawnObject();
            }

            triedToSpawn = true;
        }
    }

    private void setDirection()
    {
        // Set starting direction
        if (startDirection == 1)
        {
            // Move up
            spawnObject.GetComponent<Goon_Flying>().startMovingDown = false;
        }
        else
        {
            // Move down
            spawnObject.GetComponent<Goon_Flying>().startMovingDown = true;
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
