using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereComponent : MonoBehaviour
{
    private Rigidbody rigidbody;
    
    void Start()
    {
        this.rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    public void EnableGravity()
    {
        this.rigidbody.useGravity = true;
    }
}
