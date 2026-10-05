using UnityEngine;
using System.Collections.Generic;
public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private List<GameObject> spawnPoints;
    void Start()
    {
        foreach (GameObject spawnPoint in spawnPoints)
        {
            // Debug.Log(spawnPoint.name + " --- " + SceneTransitionData.targetSpawnPoint);
            if (spawnPoint.name == SceneTransitionData.targetSpawnPoint)
            {
                player.transform.position = spawnPoint.transform.position;
                return;
            }
        }
        player.transform.position = Vector3.zero; 
    }
}
