using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HELI
{
    public class KeyboardInput : BaseInput
    {
        [Header("Keyboard Input Variables")]
        protected float throttleInput = 0;
        public float ThrottleInput
        {
            get { return throttleInput; }
        }
        protected float collectiveInput = 0;
        public float CollectiveInput
        {
            get { return collectiveInput; }
        }
        protected Vector2 cyclicInput = Vector2.zero;
        public Vector2 CyclicInput
        {
            get { return cyclicInput; }
        }
        protected float pedalInput = 0;
        public float PedalInput
        {
            get { return pedalInput; }
        }
        protected override void HandleInputs()
        {
            base.HandleInputs();
            HandleThrottle();
            HandleCollective();
            HandleCyclic();
            HandlePedal();

            ClampInput();
        }
        protected virtual void HandleThrottle()
        {
            throttleInput = Input.GetAxis("Throttle");
        }
        protected virtual void HandleCollective()
        {
            collectiveInput = Input.GetAxis("Collective");
        }
        protected virtual void HandleCyclic()
        {
            cyclicInput.x = horizontal;
            cyclicInput.y = vertical;
        }
        protected virtual void HandlePedal()
        {
            pedalInput = Input.GetAxis("Pedal");
        }
        protected void ClampInput()
        {
            throttleInput = Mathf.Clamp(throttleInput, -1, 1);
            collectiveInput = Mathf.Clamp(collectiveInput, -1, 1);
            cyclicInput = Vector2.ClampMagnitude(cyclicInput, 1);
            pedalInput = Mathf.Clamp(pedalInput, -1, 1);
        }
    }
}
