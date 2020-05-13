using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HELI
{
    public interface IHeliRotor
    {
        void UpdateRotor(float dps, InputController input);
    }
}
