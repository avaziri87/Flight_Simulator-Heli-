using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMarker : MonoBehaviour
{
    [SerializeField] Transform helicopter = null;
    [SerializeField] GameObject marker = null;

    private void Update()
    {
        float distance = Vector3.Distance(helicopter.position, transform.position);
        if (distance < 5) marker.SetActive(false);
        else marker.SetActive(true);
        transform.position = new Vector3(helicopter.position.x, 1, helicopter.position.z);
    }
}
