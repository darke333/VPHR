using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class HeaterGrabAction : MonoBehaviour
{

    VRTK_InteractableObject Controller;
    public GameObject Heater;
    public GameObject SecondHeater;

    // Start is called before the first frame update
    void Start()
    {
        Controller = gameObject.GetComponent<VRTK_InteractableObject>();
        Controller.InteractableObjectUngrabbed += Controller_InteractableObjectUngrabbed;
        Controller.InteractableObjectGrabbed += Controller_InteractableObjectGrabbed;
    }

    private void Controller_InteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
    {
        if (Heater)
        {
            if (GameObject.FindGameObjectWithTag("Controller").GetComponent<EducationControll>().AmpulPrepeared || Heater.tag == "AmpulTriggerZone" || gameObject.name == "HeaterTriggerZone")
            {
                Heater.GetComponent<Heater_V2>().Grabb(gameObject.tag);
            }
        }
        if (SecondHeater)
        {
            SecondHeater.GetComponent<Heater_V2>().Grabb(gameObject.tag);
        }

    }

    private void Controller_InteractableObjectUngrabbed(object sender, InteractableObjectEventArgs e)
    {
        if (Heater)
        {
            Heater.GetComponent<Heater_V2>().UnGrabb(gameObject);

        }
        if (SecondHeater)
        {
            SecondHeater.GetComponent<Heater_V2>().UnGrabb(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Controller.IsGrabbed())
        {
            if (Heater)
            {
                if (GameObject.FindGameObjectWithTag("Controller").GetComponent<EducationControll>().AmpulPrepeared || Heater.tag == "AmpulTriggerZone" || Heater.name == "HeaterTriggerZone")
                {
                    Heater.GetComponent<Heater_V2>().Grabb(gameObject.tag);
                }
            }
            if (SecondHeater)
            {
                SecondHeater.GetComponent<Heater_V2>().Grabb(gameObject.tag);
            }
        }
    }
}
