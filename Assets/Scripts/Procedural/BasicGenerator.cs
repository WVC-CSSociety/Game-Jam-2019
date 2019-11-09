using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BasicGenerator", menuName = "Goat Game/Generators/Basic Gnerator", order = 1)]
public class BasicGenerator : Generator
{
    public bool generateFlat = false;

    public override GameObject GeneratePillar(int x, int y)
    {
        var newPillar = GameObject.CreatePrimitive(PrimitiveType.Cube);
        newPillar.name = "Pillar(" + x.ToString() + ", " + y.ToString() + ")";
        newPillar.transform.position = new Vector3(x*ringWidth, 0, y*ringWidth);
        float height = x * y;
        height = Mathf.Abs(height);
        if (height < 1) height = 1;
        if (generateFlat) height = 1;
        newPillar.transform.localScale = new Vector3(ringWidth, height, ringWidth);
        return newPillar;

    }
}
