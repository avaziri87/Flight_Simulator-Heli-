using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HELI
{
    public class KeyboardInput : BaseInput
    {
        [Header("GUI size")]
        [SerializeField] float guiWidth = 0;
        [SerializeField] float guiHeight = 0;
        [Space]
        [Header("Keyboard Input Variables")]
        public float throttleInput = 0;
        public float RawThrottleInput
        {
            get { return throttleInput; }
        }
        public float stickyThrottle = 0;
        public float StickyThrottle
        {
            get { return stickyThrottle; }
        }
        public float collectiveInput = 0;
        public float clampCollective = 1;
        public float RawCollectiveInput
        {
            get { return collectiveInput; }
        }
        public float stickyCollectiveInput = 0;
        public float StickyCollectiveInput
        {
            get { return stickyCollectiveInput; }
        }
        public Vector2 cyclicInput = Vector2.zero;
        public float clampCyclic = 1;
        public Vector2 CyclicInput
        {
            get { return cyclicInput; }
        }
        public float pedalInput = 0;
        public float clampPedal = 1;
        public float PedalInput
        {
            get { return pedalInput; }
        }
        public bool hoverInput;
        public bool HoverInput
        {
            get { return hoverInput; }
        }
        protected override void HandleInputs()
        {
            base.HandleInputs();
            //input methods
            HandleThrottle();
            HandleCollective();
            HandleCyclic();
            HandlePedal();
            HandleHover();

            //utility methods
            ClampInput();
            HandleStickyThrottle();
            HandleStickyCollective();
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
        protected virtual void HandleHover()
        {
            hoverInput = Input.GetButtonDown("Hover");
        }
            protected void ClampInput()
            {
                throttleInput = Mathf.Clamp(throttleInput, -1, 1);
                collectiveInput = Mathf.Clamp(collectiveInput, -clampCollective, clampCollective);
                cyclicInput = Vector2.ClampMagnitude(cyclicInput, clampCyclic);
                pedalInput = Mathf.Clamp(pedalInput, -clampPedal, clampPedal);
            }

        protected void HandleStickyThrottle()
        {
            stickyThrottle += RawThrottleInput*Time.deltaTime;
            stickyThrottle = Mathf.Clamp01(stickyThrottle);
        }
        protected void HandleStickyCollective()
        {
            stickyCollectiveInput += -collectiveInput * Time.deltaTime;
            stickyCollectiveInput = Mathf.Clamp01(stickyCollectiveInput);
        }
        private void OnGUI()
        {
            GUI.Label(new Rect(25, 25, 200, 30), "Input Values");
            GUI.Label(new Rect(25, 55, 500, 30), "throttle Input: " + throttleInput + " Triggers control Throttle: right increase; left decrease");
            GUI.Label(new Rect(25, 85, 200, 30), "sticky Throttle: " + stickyThrottle);
            GUI.Label(new Rect(25, 115, 500, 30), "collective Input: " + collectiveInput + " Right joystick controls Colective: right increase; left decrease");
            GUI.Label(new Rect(25, 145, 200, 30), "sticky Collective: " + stickyCollectiveInput);
            GUI.Label(new Rect(25, 175, 500, 30), "cyclic Input: " + cyclicInput + " left joystick controls Cyclic");
            GUI.Label(new Rect(25, 205, 500, 30), "pedal Input: " + pedalInput + " Right joystick controls Colective: up increase; down decrease");
        }
    }

}
