using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BasicGenerator", menuName = "Goat Game/Generators/Basic Gnerator", order = 1)]
public class BasicGenerator : Generator
{
    public bool generateFlat = false;

    public override List<GameObject> GeneratePillar(int x, int y, int width)
    {
        GameObject newPillar = null;
        if(InGameManager.instance.terrainPrefab != null)
        {
            newPillar = GameObject.Instantiate(InGameManager.instance.terrainPrefab);
        }
        else newPillar = GameObject.CreatePrimitive(PrimitiveType.Cube);
        newPillar.name = "Pillar(" + x.ToString() + ", " + y.ToString() + ")";
        newPillar.transform.position = new Vector3(x*width, 0, y*width);
        float height = CreatePillarHeight(x,y);        
        if (generateFlat) height = 1;
        newPillar.transform.localScale = new Vector3(width, height, width);

        Vector3 pickupLocation = newPillar.transform.position;
        pickupLocation.y += newPillar.transform.localScale.y/2;
        List<GameObject> createdObjects = new List<GameObject>(2) { newPillar};
        if (InGameManager.instance.powerUpPrefab != null)
        {
            int chance = Random.Range(0, 100);
            if (InGameManager.instance.pickupChance > chance)
            {
                GameObject powerUpObject = GameObject.Instantiate(InGameManager.instance.powerUpPrefab);
                pickupLocation.y += powerUpObject.transform.localScale.y / 2;
                powerUpObject.transform.position = pickupLocation;
                createdObjects.Add(powerUpObject);
            }
        }
        return createdObjects;
    }

    public virtual float CreatePillarHeight(int x, int y)
    {
        var returnValue = x * y;
        returnValue = Mathf.Abs(returnValue);
        if (returnValue < 1) returnValue = 1;
        return returnValue;
    }
}
