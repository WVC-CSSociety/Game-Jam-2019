using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class ChunkManager
{
    public int chunkWidth;

    Dictionary<Tuple<int, int>, List<GameObject>> chunkObjects = null;

    public ChunkManager(int chunkWidth)
    {
        this.chunkWidth = chunkWidth;

        chunkObjects = new Dictionary<Tuple<int, int>, List<GameObject>>();
    }

    public List<GameObject> GetObjects(int x, int y)
    {
        return chunkObjects[new Tuple<int, int>(x, y)];
    }

    public void AddObjectToChunk(GameObject gameObj, int x, int y)
    {
        if(chunkObjects.ContainsKey(new Tuple<int, int>(x,y)))
        {
            chunkObjects[new Tuple<int, int>(x, y)].Add(gameObj);
        }
        else
        {            
            chunkObjects.Add(new Tuple<int, int>(x, y), new List<GameObject>() { gameObj });
        }
    }
    public void AddObjectToChunk(List<GameObject> gameObjs, int x, int y)
    {
        if (chunkObjects.ContainsKey(new Tuple<int, int>(x, y)))
        {
            chunkObjects[new Tuple<int, int>(x, y)].AddRange(gameObjs);
        }
        else
        {
            chunkObjects.Add(new Tuple<int, int>(x, y), gameObjs);
        }
    }

    public bool RemoveObjectFromChunk(GameObject gameObj, int x, int y)
    {
        if (chunkObjects.ContainsKey(new Tuple<int, int>(x, y)))
        {
            var objectList = chunkObjects[new Tuple<int, int>(x, y)];
            var sucess = objectList.Remove(gameObj);
            if (objectList.Count <= 0) chunkObjects.Remove(new Tuple<int, int>(x, y));
            return sucess;
        }
        return false;
    }    
    
}
