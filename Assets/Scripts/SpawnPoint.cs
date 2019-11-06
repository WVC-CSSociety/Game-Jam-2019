using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "SpawnPoint";
    }    

    public static SpawnPoint GetSpawnPoint(string spawnName)
    {
        var spawns = GetAllSpawnPoints();

        foreach (var curSpawn in spawns)
        {
            if (curSpawn.name == spawnName) return curSpawn;
        }
        if (spawns.Count == 0) return null;
        return spawns[0];
    }

    public static List<SpawnPoint> GetAllSpawnPoints()
    {
        var spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        List<SpawnPoint> allSpawnPoints = new List<SpawnPoint>();

        foreach (GameObject curSpawn in spawnPoints)
        {
            allSpawnPoints.Add(curSpawn.GetComponent<SpawnPoint>());
        }
        return allSpawnPoints;
    }
}
