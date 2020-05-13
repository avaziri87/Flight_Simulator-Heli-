using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

namespace HELI
{
    [CustomEditor(typeof(KeyboardInput))]
    public class KeyboardInputEditor : Editor
    {
        KeyboardInput targetInput = null;

        private void OnEnable()
        {
            targetInput = (KeyboardInput)target;
        }
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            DrawDebugUI();
            Repaint();
        }
        private void DrawDebugUI()
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            EditorGUILayout.Space();
            EditorGUI.indentLevel++;
            EditorGUILayout.LabelField("Throttle: " + targetInput.RawThrottleInput.ToString("0.00"), EditorStyles.boldLabel);
            EditorGUILayout.LabelField("Collective: " + targetInput.CollectiveInput.ToString("0.00"), EditorStyles.boldLabel);
            EditorGUILayout.LabelField("Cyclic: " + targetInput.CyclicInput.ToString("0.00"), EditorStyles.boldLabel);
            EditorGUILayout.LabelField("Pedal: " + targetInput.PedalInput.ToString("0.00"), EditorStyles.boldLabel);
            EditorGUI.indentLevel--;
            EditorGUILayout.EndVertical();
        }
    }
}
