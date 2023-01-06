using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereFactory
{
    public SphereComponent CreateSphere(Vector3 position, bool mustUseGravity)
    {
        var sphere = GameObject.Instantiate(PrefabResolverUtility.SpherePrefab, position, Quaternion.identity);
        
        var rigidbody = sphere.AddComponent<Rigidbody>();
        rigidbody.useGravity = mustUseGravity;

        var sphereComponent = sphere.AddComponent<SphereComponent>();

        return sphereComponent;
    }
}
