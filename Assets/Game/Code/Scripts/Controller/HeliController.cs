using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HELI
{
    [RequireComponent(typeof(InputController), typeof(KeyboardInput), typeof(XboxInput))]
    public class HeliController : BaseRBController
    {
        [Header("Controller Properties")]
        private InputController inputController;
        protected override void HandlePhysics()
        {
            inputController = GetComponent<InputController>();
            if (inputController)
            {
                HandleEngine();
                HandleCharacteristics();
            }
        }

        protected virtual void HandleCharacteristics()
        {
            
        }

        protected virtual void HandleEngine()
        {
            
        }
    }
}
