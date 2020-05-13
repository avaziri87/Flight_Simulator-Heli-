using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HELI
{
    public class KeyboardInput : BaseInput
    {
        [Header("Keyboard Input Variables")]
        [SerializeField] float throttleInput = 0;
        public float ThrottleInput
        {
            get { return throttleInput; }
        }
        [SerializeField] float collectiveInput = 0;
        public float CollectiveInput
        {
            get { return collectiveInput; }
        }
        [SerializeField] Vector2 cyclicInput = Vector2.zero;
        public Vector2 CyclicInput
        {
            get { return cyclicInput; }
        }
        [SerializeField] float pedalInput = 0;
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
            HandlePeddal();
        }
        void HandleThrottle()
        {
            throttleInput = Input.GetAxis("Throttle");
        }
        void HandleCollective()
        {
            collectiveInput = Input.GetAxis("Collective");
        }
        void HandleCyclic()
        {
            cyclicInput.x = horizontal;
            cyclicInput.y = vertical;
        }
        void HandlePeddal()
        {
            pedalInput = Input.GetAxis("Pedal");
        }
    }
}
