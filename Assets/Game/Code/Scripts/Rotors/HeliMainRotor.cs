using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HELI
{
    public class HeliMainRotor : MonoBehaviour, IHeliRotor
    {
        [Header("Main Rotor Properties")]
        [SerializeField] Transform leftRotor;
        [SerializeField] Transform rightRotor;
        [SerializeField] float maxPitch = 35f;

        [SerializeField] float radius = 2f;

        [HideInInspector]
        public Vector2 cyclicVal;

        private float currentRPM;
        public float CurrentRPM
        {
            get { return currentRPM; }
        }

        public void UpdateRotor(float dps, InputController input)
        {
            transform.Rotate(Vector3.up, dps * Time.deltaTime * 0.5f);
            currentRPM = (dps / 360) * 60;
            Vector3 discNormal = Vector3.Normalize(transform.up + new Vector3(-cyclicVal.x, 0f, cyclicVal.y));
            //pitch blades up and down
            if(rightRotor && leftRotor)
            {
                cyclicVal = input.CyclicInput;
                rightRotor.localRotation = Quaternion.Euler(input.StickyCollectiveInput * maxPitch, 0, 0);
                leftRotor.localRotation = Quaternion.Euler(-input.StickyCollectiveInput * maxPitch, 0, 0);
            }
        }
    }
}
