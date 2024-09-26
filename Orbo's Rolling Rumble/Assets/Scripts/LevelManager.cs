using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levelParts;
    public Transform player;
    public Vector3 initPartPosition;
    public float spawnDistance;
    public int maxParts;

    private GameObject currentPart;
    private float nextSpawnX;

    // Store parts in a queue so they can be removed when they are no longer needed
    private Queue<GameObject> spawnedParts = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // Spawn initial part
        nextSpawnX = initPartPosition.x;
        SpawnLevelPart(0);
    }

    // Update is called once per frame
    void Update()
    {
        // Spawn next part if player is close
        if (player.position.x + spawnDistance > nextSpawnX)
        {
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart(int index = -1)
    {
        // Choose random part if not specified
        if (index == -1)
        {
            index = Random.Range(0, levelParts.Length);
        }

        GameObject part = Instantiate(levelParts[index]);

        // Set position
        Vector3 position = new Vector3(nextSpawnX, initPartPosition.y, initPartPosition.z);
        part.transform.position = position;

        // Update next spawn position
        nextSpawnX += GetPartWidth(part);

        // Set current part
        currentPart = part;

        // Add part to queue
        spawnedParts.Enqueue(part);

        // Remove old parts if there are too many
        if (spawnedParts.Count > maxParts)
        {
            GameObject oldPart = spawnedParts.Dequeue();
            Destroy(oldPart);
        }

    }

    private float GetPartWidth(GameObject part)
    {
        // Get the width of the part, factoring in the scale
        BoxCollider2D collider = part.GetComponentInChildren<BoxCollider2D>();
        return collider.size.x * collider.transform.localScale.x;
    }
}
