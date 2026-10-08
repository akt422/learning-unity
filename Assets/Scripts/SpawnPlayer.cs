using UnityEngine;
using System.Collections.Generic;
public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawnPoints;
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogWarning("Player not found");
            return;
        }
        string targetName = SceneTransitionData.targetSpawnPoint;

        if (string.IsNullOrEmpty(targetName))
            return;
        foreach (GameObject spawnPoint in spawnPoints)
        {
            if (spawnPoint.name == targetName)
            {
                player.transform.position = spawnPoint.transform.position;
                SceneTransitionData.targetSpawnPoint = null;
                return;
            }
        }
        Debug.LogWarning($"Spawn point '{targetName}' not found.");
        SceneTransitionData.targetSpawnPoint = null;
    }
}
