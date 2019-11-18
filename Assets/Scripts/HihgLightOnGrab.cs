using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables.ArtificialBased;

public class HihgLightOnGrab : MonoBehaviour
{
    VRTK_InteractableObject NearGrabController;
    Outline outline;
    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<VRTK_ArtificialRotator>())
        {
            NearGrabController = gameObject.transform.parent.GetComponent<VRTK_InteractableObject>();
        }
        else
        {
            NearGrabController = GetComponent<VRTK_InteractableObject>();
        }
        outline = GetComponent<Outline>();
        NearGrabController.InteractableObjectTouched += NearGrabController_InteractableObjectTouched;
        NearGrabController.InteractableObjectGrabbed += NearGrabController_InteractableObjectGrabbed;
        NearGrabController.InteractableObjectUntouched += NearGrabController_InteractableObjectUntouched;
        outline.enabled = false;
    }

    private void NearGrabController_InteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
    {
        outline.enabled = false;
    }

    private void NearGrabController_InteractableObjectUntouched(object sender, InteractableObjectEventArgs e)
    {
        outline.enabled = false;
    }

    private void NearGrabController_InteractableObjectTouched(object sender, InteractableObjectEventArgs e)
    {
        outline.enabled = true;
    }





    // Update is called once per frame
    void Update()
    {
        
    }
}
