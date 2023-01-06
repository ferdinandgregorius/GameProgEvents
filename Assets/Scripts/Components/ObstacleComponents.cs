using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using System;
using UnityEngine;
using Random=UnityEngine.Random;

public class ObstacleComponents : MonoBehaviour
{
    private Subject<Unit> ObstacleCollisionSubject;
    private Subject<Unit> ObstacleColorSubject;

    public IObservable<Unit> OnObstacleCollidedObservable
    {
        get
        {
            return this.ObstacleCollisionSubject.AsObservable();
        }
    }

    public IObservable<Unit> OnObstacleColorObservable
    {
        get
        {
            return this.ObstacleColorSubject.AsObservable();
        }
    }

    private static readonly float TIME_BEFORE_HIDING_AFTER_COLLISION_IN_SECONDS = 5f;

    ObstacleComponents()
    {
        this.ObstacleCollisionSubject = new Subject<Unit>();
        this.ObstacleColorSubject = new Subject<Unit>();
    }
    
    public void OnCollisionEnter(Collision collision)
    {
        this.StartCoroutine("HideAfterSeconds", ObstacleComponents.TIME_BEFORE_HIDING_AFTER_COLLISION_IN_SECONDS);
        this.ObstacleCollisionSubject.OnNext(Unit.Default);
    }

    public void CollisionChangeColor()
    {
        Debug.Log("function used");
        this.transform.GetComponent<Renderer>().material.color =
                    new Color(Random.value, Random.value, Random.value, 1f);
        this.ObstacleColorSubject.OnNext(Unit.Default);
    }
    
    private IEnumerator HideAfterSeconds(float timeInSeconds)
    {
        yield return new WaitForSecondsRealtime(timeInSeconds);
        this.gameObject.SetActive(false);
    }
}
