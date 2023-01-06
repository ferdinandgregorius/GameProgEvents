using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFactory
{
    public ObstacleComponents CreateObstacle(Vector3 position)
    {
        var obstacle = GameObject.Instantiate(PrefabResolverUtility.ObstaclePrefab, position, Quaternion.identity);
        var obstacleComponent = obstacle.AddComponent<ObstacleComponents>();

        return obstacleComponent;
    }
}
