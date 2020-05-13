using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRBController : MonoBehaviour
{
    protected Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if(rb)
        {
            HandlePhysics();
        }
    }
    protected virtual void HandlePhysics()
    {
        
    }
}
