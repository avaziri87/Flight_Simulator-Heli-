using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTorque : MonoBehaviour
{
    [SerializeField] float torqueSpeed = 1;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rb)
        {
            rb.AddTorque(Vector3.up * torqueSpeed);
        }
    }
}
