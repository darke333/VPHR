using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Heater_V2 : MonoBehaviour
{
    public GameObject Fixed;
    public GameObject Heat;
    public bool IsStaying;
    public bool IsFulled;
    Collider col;
    MeshRenderer mesh;
    public string HeatTag;



    void OnTriggerExit(Collider other)
    {
        
        if (other.tag == HeatTag)
        {
            IsStaying = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == HeatTag)
        {
            if (gameObject.tag == "EndAmpulTrigger")
            {
                if (other.GetComponent<AmpulAtributs>().EndPinned)
                {
                    IsStaying = true;
                }
            }
            else
            {
                IsStaying = true;
            }
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        IsFulled = false;
        col = gameObject.GetComponent<Collider>();
        mesh = gameObject.GetComponent<MeshRenderer>();
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        IsStaying = false;

    }



    public void Grabb(string tag)
    {
        HeatTag = tag;
        if (!IsFulled)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
        gameObject.GetComponent<Collider>().enabled = true;
    }



    public void UnGrabb(GameObject FixedPart)
    {
        
        if (IsStaying && !IsFulled)
        {
            FixedPart.AddComponent<FixedJoint>();
            foreach (FixedJoint jointt in FixedPart.GetComponents<FixedJoint>())
            {
                if (jointt.breakForce != 200)
                {
                    FixedPart.transform.position = gameObject.transform.position;
                    FixedPart.transform.rotation = gameObject.transform.rotation;
                    jointt.connectedBody = Heat.GetComponent<Rigidbody>();
                    jointt.breakForce = 200;

                }
            }
            Fixed = FixedPart;
            IsFulled = true;
            if (gameObject.name == "HeaterTriggerZone")
            {
                GameObject.FindGameObjectWithTag("Controller").GetComponent<EducationControll>().HeaterIn = true;
            }
            if (gameObject.tag == "AmpulTriggerZone")
            {
                GameObject.FindGameObjectWithTag("Controller").GetComponent<EducationControll>().CountHeatedAmpuls(1);
            }
            if (gameObject.tag == "EndAmpulTrigger")
            {
                GameObject.FindGameObjectWithTag("Controller").GetComponent<EducationControll>().AmpulInserted = true;
                GameObject.FindGameObjectWithTag("Controller").GetComponent<EducationControll>().Pumper.enabled = true;
                GameObject.FindGameObjectWithTag("Controller").GetComponent<EducationControll>().Pumper.GetComponent<PumpWork>().Ampul = Fixed.GetComponent<AmpulAtributs>();

            }
        }
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }


    void Update()
    {
        if (Fixed)
        {
            if (!Fixed.GetComponent<FixedJoint>())
            {

                Fixed = null;
                IsFulled = false;
                if (gameObject.name == "HeaterTriggerZone")
                {
                    GameObject.FindGameObjectWithTag("Controller").GetComponent<EducationControll>().HeaterIn = false;
                }
                if (gameObject.tag == "AmpulTriggerZone")
                {
                    GameObject.FindGameObjectWithTag("Controller").GetComponent<EducationControll>().CountHeatedAmpuls(-1); 
                }
                if (gameObject.tag == "EndAmpulTrigger")
                {
                    GameObject.FindGameObjectWithTag("Controller").GetComponent<EducationControll>().AmpulInserted = false;
                    GameObject.FindGameObjectWithTag("Controller").GetComponent<EducationControll>().Pumper.enabled = false;

                }
            }
        }
    }
}
