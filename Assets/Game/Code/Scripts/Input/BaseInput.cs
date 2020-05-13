using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HELI
{
    public class BaseInput : MonoBehaviour
    {
        [Header("Base Input Variables")]
        protected float vertical = 0f;
        protected float horizontal = 0f;
        void Update()
        {
            HandleInputs();
        }
        protected virtual void HandleInputs()
        {
            vertical = Input.GetAxis("Vertical");
            horizontal = Input.GetAxis("Horizontal");
        }
    }
}
