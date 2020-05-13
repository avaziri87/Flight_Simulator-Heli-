using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace HELI
{
    public class HeliRotorcontroller : MonoBehaviour
    {
        [SerializeField] List<IHeliRotor> rotors;

        private void Start()
        {
            rotors = GetComponentsInChildren<IHeliRotor>().ToList<IHeliRotor>();
        }
        public void UpdateRotors(InputController input, float currentRPM)
        {
            //calculate degres per second (dps)
            float dps = (currentRPM * 360f) / 60f;
            if(rotors.Count>0)
            {
                foreach(var rotor in rotors)
                {
                    rotor.UpdateRotor(dps, input);
                }
            }
        }
    }
}
