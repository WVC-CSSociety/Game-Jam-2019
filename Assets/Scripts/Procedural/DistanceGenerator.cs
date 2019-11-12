using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DistanceGenerator", menuName = "Goat Game/Generators/Distance Gnerator", order = 1)]
public class DistanceGenerator : BasicGenerator
{
    public override float CreatePillarHeight(int x, int y)
    {
        return Mathf.Abs(x) + Mathf.Abs(y);
    }
}
