using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HELI;

public class NewForces : BaseRBController
{
    [SerializeField] float maxSpeed = 1;
    [SerializeField] Vector3 moveDirection = Vector3.forward;

    protected override void HandlePhysics()
    {
        rb.AddForce(moveDirection * maxSpeed);
    }
}
