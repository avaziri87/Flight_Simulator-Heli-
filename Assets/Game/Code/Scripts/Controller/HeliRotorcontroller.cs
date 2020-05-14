using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace HELI
{
    public class HeliRotorcontroller : MonoBehaviour
    {
        [SerializeField] float maxDps = 3000f;
        [SerializeField] List<IHeliRotor> rotors;

        private void Start()
        {
            rotors = GetComponentsInChildren<IHeliRotor>().ToList<IHeliRotor>();
        }
        public void UpdateRotors(InputController input, float currentRPM)
        {
            //calculate degres per second (dps)
            float dps = (currentRPM * 360f) / 60f;
            dps = Mathf.Clamp(dps, 0, maxDps);
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
