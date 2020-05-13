using HELI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTorque : BaseRBController
{
    [SerializeField] float torqueSpeed = 1;
    [SerializeField] Vector3 rotationDirection = Vector3.up;

    protected override void HandlePhysics()
    {
        Vector3 wantedTorque = Vector3.up * torqueSpeed;
        rb.AddTorque(wantedTorque);
    }
}
