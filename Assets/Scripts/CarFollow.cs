using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFollow : MonoBehaviour
{

    public Transform CarBody;
    
    void FixedUpdate()
    {
        gameObject.transform.position = CarBody.position;
        gameObject.transform.rotation = CarBody.rotation;
    }
}
