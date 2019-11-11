using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Generator : ScriptableObject
{
    public int ringWidth = 3;

    List<List<GameObject>> pillarObjects = new List<List<GameObject>>();

    public virtual void GenerateSpawn()
    {
        InGameManager inGameManager = FindInGameManager();

        GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
        if (inGameManager.groundMaterial != null)
        {
            var renderer = ground.GetComponent<Renderer>();
            renderer.material = inGameManager.groundMaterial;
        }

        GameObject defaultSpawn = new GameObject("SpawnPointDefault");
        defaultSpawn.AddComponent<SpawnPoint>();
        defaultSpawn.transform.Translate(0,1,0);
    }
    public virtual void GenerateRing(int ringID)
    {
        //Generate top
        for(int x = -(ringID+1); x <= (ringID+1); x++)
        {
            GeneratePillar(x, (ringID+1));
        }

        //Generate bottom
        for (int x = -(ringID+1); x <= ringID + 1; x++)
        {
            GeneratePillar(x, -(ringID +1));
        }

        //Generate left
        for (int y = -ringID; y <= ringID; y++)
        {
            GeneratePillar((ringID+1), y);
        }

        //Generate right
        for (int y = -ringID; y <= ringID; y++)
        {
            GeneratePillar(-(ringID + 1), y);
        }
    }
    public abstract GameObject GeneratePillar(int x, int y);

    public InGameManager FindInGameManager()
    {
        var foundInGameManager = Object.FindObjectOfType<InGameManager>();

        return foundInGameManager;
    }
}
