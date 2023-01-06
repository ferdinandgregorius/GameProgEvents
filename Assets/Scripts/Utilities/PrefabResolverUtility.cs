using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabResolverUtility : MonoBehaviour
{
    [SerializeField] 
    private GameObject obstaclePrefab;
    
    [SerializeField] 
    private GameObject spherePrefab;
    
    [SerializeField] 
    private GameObject scoreCounterPrefab;
    
    [SerializeField] 
    private GameObject planePrefab;

    private static GameObject obstaclePrefabStatic;
    private static GameObject spherePrefabStatic;
    private static GameObject scoreCounterPrefabStatic;
    private static GameObject planePrefabStatic;

    void Awake()
    {
        PrefabResolverUtility.obstaclePrefabStatic = obstaclePrefab;
        PrefabResolverUtility.spherePrefabStatic = spherePrefab;
        PrefabResolverUtility.scoreCounterPrefabStatic = scoreCounterPrefab;
        PrefabResolverUtility.planePrefabStatic = planePrefab;
    }

    public static GameObject ObstaclePrefab
    {
        get
        {
            return PrefabResolverUtility.obstaclePrefabStatic;
        }
    }

    public static GameObject SpherePrefab
    {
        get
        {
            return PrefabResolverUtility.spherePrefabStatic;
        }
    }
    
    public static GameObject ScoreCounterPrefab
    {
        get
        {
            return PrefabResolverUtility.scoreCounterPrefabStatic;
        }
    }
    
    public static GameObject PlanePrefab
    {
        get
        {
            return PrefabResolverUtility.planePrefabStatic;
        }
    }
}
