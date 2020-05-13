using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HELI
{
    public enum InputType
    {
        Keyboard,
        Xbox,
        Mobile
    }
    [RequireComponent(typeof(KeyboardInput), typeof(XboxInput))]
    public class InputController: MonoBehaviour
    {
        [Header("Input Properties")]
        public InputType inputType = InputType.Keyboard;

        KeyboardInput keyboardInput;
        XboxInput xboxInput;

        float throttleInput;
        public float ThrottleInput
        {
            get { return throttleInput; }
        }
        float stickyThrottle;
        public float StickyThrottle
        {
            get { return stickyThrottle; }
        }
        float collectiveInput;
        public float CollectiveInput
        {
            get { return collectiveInput; }
        }
        Vector2 cyclicInput =  Vector2.zero;
        public Vector2 CyclicInput
        {
            get { return cyclicInput; }
        }
        float pedalInput;
        public float PedalInput
        {
            get { return pedalInput; }
        }
        private void Start()
        {
            keyboardInput = GetComponent<KeyboardInput>();
            xboxInput = GetComponent<XboxInput>();
            if (keyboardInput && xboxInput)
            {
                SetInputType(inputType);
            }
        }
        private void Update()
        {
            if(keyboardInput && xboxInput)
            {
                switch (inputType)
                {
                    case InputType.Keyboard:
                        throttleInput = keyboardInput.RawThrottleInput;
                        collectiveInput = keyboardInput.CollectiveInput;
                        cyclicInput = keyboardInput.CyclicInput;
                        pedalInput = keyboardInput.PedalInput;
                        stickyThrottle = keyboardInput.StickyThrottle;
                        break;
                    case InputType.Xbox:
                        throttleInput = xboxInput.RawThrottleInput;
                        collectiveInput = xboxInput.CollectiveInput;
                        cyclicInput = xboxInput.CyclicInput;
                        pedalInput = xboxInput.PedalInput;
                        stickyThrottle = xboxInput.StickyThrottle;
                        break;
                    case InputType.Mobile:
                        break;
                    default:
                        break;
                }
            }

        }
        void SetInputType(InputType type)
        {
            if (type == InputType.Keyboard)
            {
                keyboardInput.enabled = true;
                xboxInput.enabled = false;
            }
            if (type == InputType.Xbox)
            {
                keyboardInput.enabled = false;
                xboxInput.enabled = true;
            }
        }
    }
}

