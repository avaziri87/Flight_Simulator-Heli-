using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HELI
{
    public class RotorBlur : MonoBehaviour, IHeliRotor
    {
        [Header("Rotor Blur Properties")]
        [SerializeField] float maxDPS = 1000f;
        [SerializeField] List<GameObject> blades = new List<GameObject>();
        [SerializeField] GameObject blurGeo;
        [SerializeField] Material blurMat;

        [SerializeField] List<Texture2D> blurTextures = new List<Texture2D>();
        public void UpdateRotor(float dps, InputController input)
        {
            float normalizedDPS = Mathf.InverseLerp(0f, maxDPS, dps);
            int blurTexID = Mathf.FloorToInt(normalizedDPS * blurTextures.Count - 1);
            blurTexID = Mathf.Clamp(blurTexID, 0, blurTextures.Count - 1);

            if (blurMat && blurTextures.Count > 0)
            {
                blurMat.SetTexture("_MainTex",blurTextures[blurTexID]);
            }
            if(blurTexID > 2 && blades.Count >0)
            {
                HandleBladVis(false);
            }
            else
            {
                HandleBladVis(true);
            }
        }
        void HandleBladVis(bool value)
        {
            foreach (var blade in blades)
            {
                blade.SetActive(value);
            }
        }
    }
}
