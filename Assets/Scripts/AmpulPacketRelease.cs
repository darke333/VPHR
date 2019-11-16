using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables;
using VRTK.GrabAttachMechanics;
using VRTK;

public class AmpulPacketRelease : MonoBehaviour
{
    VRTK_BaseControllable controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = (controller == null ? GetComponent<VRTK_BaseControllable>() : controller);
        controller.MaxLimitReached += Controller_MaxLimitReached;
        gameObject.GetComponent<VRTK_InteractableObject>().grabAttachMechanicScript = gameObject.GetComponent<VRTK_TrackObjectGrabAttach>();
        gameObject.AddComponent<Rigidbody>();

    }

    private void Controller_MaxLimitReached(object sender, ControllableEventArgs e)
    {
        gameObject.GetComponent<VRTK_InteractableObject>().grabAttachMechanicScript = gameObject.GetComponent<VRTK_TrackObjectGrabAttach>();
        gameObject.AddComponent<Rigidbody>();
    }

}
