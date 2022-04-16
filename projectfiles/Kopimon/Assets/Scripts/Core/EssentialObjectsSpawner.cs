using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialObjectsSpawner : MonoBehaviour
{
    [SerializeField] GameObject essentialObjectsPrefab;
    // RK : Spawn all essential objects such as battle system, player on loading of a scene
    // IMPORTANT! For every new scene, create an empty game object under the scene and name it "EssentialObjectsSpawner", then attach this script to the game object.
    // Otherwise player will not spawn after scene transition
    private void Awake()
    {
        var existingObjects = FindObjectsOfType<EssentialObjects>();
        if (existingObjects.Length == 0)
        {
            // if there is a grid, then spawn at it's center
            var spawnPos = new Vector3(0, 0, 0);

            var grid = FindObjectOfType<Grid>();
            if (grid != null)
                spawnPos = grid.transform.position;

            Instantiate(essentialObjectsPrefab, spawnPos, Quaternion.identity);
        }
    }
}
