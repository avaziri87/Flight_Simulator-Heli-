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
        void Start()
        {

        }
        public void UpdateRotor(float dps, InputController input)
        {
            //rotate blades
            transform.Rotate(Vector3.up, dps);

            //pitch blades up and down
            if(rightRotor && leftRotor)
            {
                rightRotor.localRotation = Quaternion.Euler(-input.CollectiveInput * maxPitch, 0, 0);
                leftRotor.localRotation = Quaternion.Euler(input.CollectiveInput * maxPitch, 0, 0);
            }
        }
    }
}
