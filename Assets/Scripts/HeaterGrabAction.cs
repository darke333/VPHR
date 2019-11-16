using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class HeaterGrabAction : MonoBehaviour
{

    VRTK_InteractableObject Controller;
    public GameObject Heater;

    // Start is called before the first frame update
    void Start()
    {
        Controller = gameObject.GetComponent<VRTK_InteractableObject>();
        Controller.InteractableObjectUngrabbed += Controller_InteractableObjectUngrabbed;
        Controller.InteractableObjectGrabbed += Controller_InteractableObjectGrabbed;
    }

    private void Controller_InteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
    {
        Heater.GetComponent<Heater_V2>().Grabb(gameObject.tag);

    }

    private void Controller_InteractableObjectUngrabbed(object sender, InteractableObjectEventArgs e)
    {
        Heater.GetComponent<Heater_V2>().UnGrabb(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
