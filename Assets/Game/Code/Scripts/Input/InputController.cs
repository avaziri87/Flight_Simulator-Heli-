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
    public class InputController: MonoBehaviour
    {
        public InputType inputType = InputType.Keyboard;

        [Header("Input Components")]
        public KeyboardInput keyboardInput;
        public XboxInput xboxInput;

        private void Start()
        {
            SetInputType(inputType);
        }

        void SetInputType(InputType type)
        {
            if(keyboardInput && xboxInput)
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
}
