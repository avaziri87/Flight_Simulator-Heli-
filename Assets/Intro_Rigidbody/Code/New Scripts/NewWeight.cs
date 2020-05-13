using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWeight : MonoBehaviour
{
    [Header("Weight Properties")]
    [SerializeField] float weight_lbs = 10;
    [SerializeField] float lbs_kg = 0.454f;
    [SerializeField] float kg_lbs = 2.205f;
    [SerializeField] float weight;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        float final_kg = weight_lbs * lbs_kg;
        rb = GetComponent<Rigidbody>();
        if(rb)
        {
            rb.mass = final_kg;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
