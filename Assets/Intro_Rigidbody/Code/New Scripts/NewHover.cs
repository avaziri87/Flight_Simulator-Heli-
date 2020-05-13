using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewHover : MonoBehaviour
{
    [SerializeField] float weight;
    [Header("Hover Properties")]
    [SerializeField] float hoverHeight = 3.0f;
    [SerializeField] Transform hoverPosition = null;
    [SerializeField] float torqueForce = 1f;
    [SerializeField] float dragFactor = 0.5f;
    [SerializeField] float angularVelocity;

    Rigidbody rb;
    float groundDistance;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if(rb)
        {
            weight = rb.mass * Physics.gravity.magnitude;
        }
    }


    void FixedUpdate()
    {
        if (rb)
        {
            CalculateDistanceToGround();
            HandleHoverForce();
            HandleTorque();
            HandleDrag();
            angularVelocity = rb.angularVelocity.y;
        }
    }
    void CalculateDistanceToGround()
    {
        Ray hoverRay = new Ray(hoverPosition.position, Vector3.down);
        Debug.DrawRay(hoverPosition.position, hoverRay.direction, Color.red);
        RaycastHit hit;
        if(Physics.Raycast(hoverRay, out hit, 100f))
        {
            if (hit.transform.tag == "ground")
            {
                groundDistance = hit.distance;
            }

        }
    }
    private void HandleHoverForce()
    {
        float groundDiference = hoverHeight - groundDistance;
        Vector3 hoverForce = Vector3.up * (1 + groundDiference);
        rb.AddForce(hoverForce * weight);
    }
    private void HandleTorque()
    {
        rb.AddTorque(Vector3.up * torqueForce);
    }
    private void HandleDrag()
    {
        float currentSpeed = rb.velocity.magnitude;
        rb.drag = currentSpeed * dragFactor;
    }
}
