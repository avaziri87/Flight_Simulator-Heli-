using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HELI
{
    public class HelicControlHandleStick : MonoBehaviour
    {
        [SerializeField] Transform stick;
        [SerializeField] float maxStickPitch;

        public void UpdateStick(InputController input)
        {
            stick.localRotation = Quaternion.Euler(input.CyclicInput.y * maxStickPitch, 0, -input.CyclicInput.x * maxStickPitch);
        }
    }
}
