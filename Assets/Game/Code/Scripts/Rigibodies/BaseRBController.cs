using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HELI
{
    [RequireComponent(typeof(Rigidbody))]
    public class BaseRBController : MonoBehaviour
    {
        [Header("Weight Properties")]
        [SerializeField] Transform centerOfGravity = null;
        [SerializeField] float weight_lbs = 10;
        [SerializeField] float lbs_kg = 0.454f;
        [SerializeField] float kg_lbs = 2.205f;
        protected float weight;
        protected Rigidbody rb;
        void Start()
        {
            float final_kg = weight_lbs * lbs_kg;
            weight = final_kg;
            rb = GetComponent<Rigidbody>();
            if (rb)
            {
                rb.mass = weight;
            }
        }
        void FixedUpdate()
        {
            if (rb)
            {
                HandlePhysics();
            }
        }
        protected virtual void HandlePhysics()
        {

        }
    }
}
