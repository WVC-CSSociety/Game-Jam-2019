using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Generator : ScriptableObject
{
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
    public virtual void GenerateRing(int ringID, int chunkWidth, ChunkManager chunkManager)
    {
        //Generate top
        for(int x = -(ringID+1); x <= (ringID+1); x++)
        {
            int newY = (ringID + 1);
            var newObject = GeneratePillar(x, newY, chunkWidth);
            if(chunkManager != null) chunkManager.AddObjectToChunk(newObject, x, newY);
        }

        //Generate bottom
        for (int x = -(ringID+1); x <= ringID + 1; x++)
        {
            int newY = -(ringID + 1);
            var newObject = GeneratePillar(x, newY, chunkWidth);
            if (chunkManager != null) chunkManager.AddObjectToChunk(newObject, x, newY);
        }

        //Generate left
        for (int y = -ringID; y <= ringID; y++)
        {
            int newX = (ringID + 1);
            var newObject = GeneratePillar(newX, y, chunkWidth);
            if (chunkManager != null) chunkManager.AddObjectToChunk(newObject, newX, y);
        }

        //Generate right
        for (int y = -ringID; y <= ringID; y++)
        {
            int newX = -(ringID + 1);
            var newObject = GeneratePillar(newX, y, chunkWidth);
            if (chunkManager != null) chunkManager.AddObjectToChunk(newObject, newX, y);
        }
    }
    public abstract List<GameObject> GeneratePillar(int x, int y, int width);

    public InGameManager FindInGameManager()
    {
        var foundInGameManager = Object.FindObjectOfType<InGameManager>();

        return foundInGameManager;
    }
}
