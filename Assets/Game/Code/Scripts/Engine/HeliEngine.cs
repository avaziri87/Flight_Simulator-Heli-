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
        float wantedHP;
        float wantedRPM;

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
            wantedHP = powerCurve.Evaluate(throttleInput) * maxHP;
            currentHP = Mathf.Lerp(currentHP, wantedHP, Time.deltaTime * powerDelay);
            //Debug.Log("current HP: " + currentHP + " target HP: " + wantedHP);

            //calculate RPM
            wantedRPM = powerCurve.Evaluate(throttleInput) * maxRPM;
            currentRPM = Mathf.Lerp(currentRPM, wantedRPM, Time.deltaTime * powerDelay);
            //Debug.Log("current RPM: " + currentRPM + " target RPM: " + wantedRPM);
        }
        private void OnGUI()
        {
            GUI.Label(new Rect(500, 25, 200, 30), "Engine values");
            GUI.Label(new Rect(500, 55, 200, 30), "Current RPM: " + currentRPM);
            GUI.Label(new Rect(500, 85, 200, 30), "Wanted RPM: " + wantedRPM);
            GUI.Label(new Rect(500, 115, 200, 30), "current HP: " + currentHP);
            GUI.Label(new Rect(500, 145, 200, 30), "Wanted HP: " + wantedHP);
        }
    }
}
