using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HELI
{
    public class HeliTail : MonoBehaviour, IHeliRotor
    {
        [Header("Tail Rotor Properties")]
        [SerializeField] float tailSpeedModifier = 1.5f;
        [SerializeField] Transform leftRotor;
        [SerializeField] Transform rightRotor;
        [SerializeField] float maxPitch = 35f;
        void Start()
        {

        }
        public void UpdateRotor(float dps, InputController input)
        {
            transform.Rotate(Vector3.right, dps * tailSpeedModifier);

            //pitch blades up and down
            if (rightRotor && leftRotor)
            {
                rightRotor.localRotation = Quaternion.Euler(0, -input.PedalInput * maxPitch, 0);
                leftRotor.localRotation = Quaternion.Euler(0, input.PedalInput * maxPitch, 0);
            }
        }
    }
}
