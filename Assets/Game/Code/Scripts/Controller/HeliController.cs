using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HELI
{
    [RequireComponent(typeof(InputController))]
    public class HeliController : BaseRBController
    {
        [Header("Helicopter Properties")]
        public List<HeliEngine> engines = new List<HeliEngine>();

        [Header("Helicopter Properties")]
        public HeliRotorcontroller rotorCtrl;

        InputController inputController;
        HeliCharacteristic characteristic;
        HelicControlHandleStick controlStick;
        public override void Start()
        {
            base.Start();
            characteristic = GetComponent<HeliCharacteristic>();
            controlStick = GetComponent<HelicControlHandleStick>();
        }
        protected override void HandlePhysics()
        {
            inputController = GetComponent<InputController>();
            if (inputController)
            {
                HandleEngine();
                HandleRotors();
                HandleCharacteristics();
                HandleControlStick();
            }
        }

        protected virtual void HandleRotors()
        {
            if(rotorCtrl && engines.Count > 0)
            {
                rotorCtrl.UpdateRotors(inputController, engines[0].CurrrentRPM);
            }
        }

        protected virtual void HandleEngine()
        {
            for(int i = 0; i < engines.Count; i++)
            {
                engines[i].UpdateEngine(inputController.StickyThrottle);
                float finalPower = engines[i].CurrrentHP;
            }
        }
        protected virtual void HandleCharacteristics()
        {
            if(characteristic)
            {
                characteristic.UpdateCharacteristic(rb, inputController);
            }
        }
        protected virtual void HandleControlStick()
        {
            if(controlStick)
            {
                controlStick.UpdateStick(inputController);
            }
        }
    }
}
