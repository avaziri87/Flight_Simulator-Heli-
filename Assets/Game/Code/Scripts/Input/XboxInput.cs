using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HELI
{
    public class XboxInput : KeyboardInput
    {
        protected override void HandleThrottle()
        {
            throttleInput = Input.GetAxis("XboxThrottleUp") - Input.GetAxis("XboxThrottleDown");
        }
        protected override void HandleCollective()
        {
            collectiveInput = Input.GetAxis("XboxCollective");
        }
        protected override void HandleCyclic()
        {
            cyclicInput.x = Input.GetAxis("XboxCyclicHorizontal");
            cyclicInput.y = Input.GetAxis("XboxCyclicVerticle");
        }
        protected override void HandlePedal()
        {
            pedalInput = Input.GetAxis("XboxPedal");
        }
    }
}
