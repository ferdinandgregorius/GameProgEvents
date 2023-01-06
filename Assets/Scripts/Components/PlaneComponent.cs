using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PlaneComponent : MonoBehaviour
{
    private Subject<Unit> PlaneCollisionSubject;
    private AudioClip audioClip;
    private AudioSource audioSource;

    public IObservable<Unit> onPlaneCollisionObservable
    {
        get
        {
            return this.PlaneCollisionSubject.AsObservable();
        }
    }

    PlaneComponent()
    {
        this.PlaneCollisionSubject = new Subject<Unit>();
    }

    public void OnCollisionEnter()
    {
        this.audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource.Play();
    }
}
