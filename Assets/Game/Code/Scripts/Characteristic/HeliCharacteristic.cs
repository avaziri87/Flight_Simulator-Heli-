using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HELI
{
    public class HeliCharacteristic : MonoBehaviour
    {
        [Header("Lift Properties")]
        [SerializeField] float maxLift = 10f;
        [SerializeField] HeliMainRotor mainRotor;
        [SerializeField] bool hover = false;
        [Space]
        [Header("Tail Rotor Properties")]
        [SerializeField] float tailForce = 2.0f;
        [Space]
        [Header("Cyclic Properties")]
        [SerializeField] float cyclicForce = 2.0f;
        [SerializeField] float cyclicForceMultiplier = 1000f;
        [Space]
        [Header("Auto Level Properties")]
        [SerializeField] float autoLevelForce = 2f;

        Vector3 flatForward;
        Vector3 flatRight;
        float forwardDot;
        float rightDot;
        public void UpdateCharacteristic(Rigidbody rb, InputController input)
        {
            HandleLift(rb, input);
            HandleCyclic(rb, input);
            HandlePedals(rb, input);

            CalculateAngles();
            AutoLeve(rb);
        }
        protected virtual void HandleLift(Rigidbody rb, InputController input)
        {
            if(mainRotor)
            {
                    Vector3 liftForce = transform.up * (Physics.gravity.magnitude + maxLift) * rb.mass;
                    float normalizeRPM = mainRotor.CurrentRPM / 500f;
                    rb.AddForce(liftForce * Mathf.Pow(normalizeRPM, 2) * Mathf.Pow(input.StickyCollectiveInput, 2), ForceMode.Force);
            }
        }
        protected virtual void HandleCyclic(Rigidbody rb, InputController input)
        {
            float cyclicZForce = input.CyclicInput.x* cyclicForce;
            rb.AddRelativeTorque(Vector3.forward * cyclicZForce, ForceMode.Acceleration);

            float cyclicXForce = -input.CyclicInput.y * cyclicForce;
            rb.AddRelativeTorque(Vector3.right * cyclicXForce, ForceMode.Acceleration);

            //apply force base on dot product
            Vector3 forwardVector = flatForward * forwardDot;
            Vector3 rightVector = flatRight * rightDot;
            Vector3 finalCyclicDirection = Vector3.ClampMagnitude(forwardVector + rightVector, 1f) * cyclicForce * cyclicForceMultiplier;
            rb.AddForce(finalCyclicDirection, ForceMode.Force);
        }
        protected virtual void HandlePedals(Rigidbody rb, InputController input)
        {
            rb.AddTorque(Vector3.up * input.PedalInput * tailForce, ForceMode.Acceleration);
        }
        private void CalculateAngles()
        {
            //calculate flat forward
            flatForward = transform.forward;
            flatForward.y = 0;
            flatForward = flatForward.normalized;
            Debug.DrawRay(transform.position, flatForward, Color.blue);
            //claculate flat right
            flatRight = transform.right;
            flatRight.y = 0;
            flatRight = flatRight.normalized;
            Debug.DrawRay(transform.position, flatRight, Color.red);
            //calculate the angles
            forwardDot = Vector3.Dot(transform.up, flatForward);
            rightDot = Vector3.Dot(transform.up, flatRight);

        }
        private void AutoLeve(Rigidbody rb)
        {
            float rightForce = -forwardDot * autoLevelForce;
            float forwardForce = rightDot * autoLevelForce;

            rb.AddRelativeTorque(Vector3.right * rightForce, ForceMode.Acceleration);
            rb.AddRelativeTorque(Vector3.forward * forwardForce, ForceMode.Acceleration);
        }
    }
}
