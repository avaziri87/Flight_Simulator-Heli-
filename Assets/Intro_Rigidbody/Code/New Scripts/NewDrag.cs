using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDrag : MonoBehaviour
{
    [Header("Drag Properties")]
    [SerializeField] float dragFactor = 0.05f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb)
        {
            float currentSpeed = rb.velocity.magnitude;
            rb.drag = currentSpeed * dragFactor;
        }
    }
}
