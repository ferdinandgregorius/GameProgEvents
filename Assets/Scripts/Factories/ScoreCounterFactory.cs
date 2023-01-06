using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounterFactory
{
    public ScoreCounterComponent CreateScoreCounter()
    {
        var scoreCounter = GameObject.Instantiate(
            PrefabResolverUtility.ScoreCounterPrefab,
            Vector3.zero, 
            Quaternion.identity
        );

        var scoreCounterComponent = scoreCounter.AddComponent<ScoreCounterComponent>();

        return scoreCounterComponent;
    }
}
