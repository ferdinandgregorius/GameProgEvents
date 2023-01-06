using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneFactory
{
    public PlaneComponent CreatePlane(Vector3 position)
    {
        var plane = GameObject.Instantiate(PrefabResolverUtility.PlanePrefab, position, Quaternion.identity);
        var planeComponent = plane.AddComponent<PlaneComponent>();

        return planeComponent;
    }
}
