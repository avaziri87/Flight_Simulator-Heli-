using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HELI
{
    public class HeliEngine : MonoBehaviour
    {
        [SerializeField] float maxHP = 140f;
        [SerializeField] float maxRPM = 2700f;
        [SerializeField] float powerDelay = 2f;
        [SerializeField] AnimationCurve powerCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));

        [SerializeField] float currentHP;
        public float CurrrentHP
        {
            get { return currentHP; }
        }
        [SerializeField] float currentRPM;
        public float CurrrentRPM
        {
            get { return currentRPM; }
        }
        void Start()
        {

        }

        public void UpdateEngine(float throttleInput)
        {
            //calculate HP
            float wantedHP = powerCurve.Evaluate(throttleInput) * maxHP;
            currentHP = Mathf.Lerp(currentHP, wantedHP, Time.deltaTime * powerDelay);
            //Debug.Log("current HP: " + currentHP + " target HP: " + wantedHP);

            //calculate RPM
            float wantedRPM = powerCurve.Evaluate(throttleInput) * maxRPM;
            currentRPM = Mathf.Lerp(currentRPM, wantedRPM, Time.deltaTime * powerDelay);
            //Debug.Log("current RPM: " + currentRPM + " target RPM: " + wantedRPM);
        }
    }
}
