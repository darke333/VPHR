using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables;
using VRTK.GrabAttachMechanics;

public class AmpulRelease : MonoBehaviour
{
    VRTK_BaseControllable controller;
    public GameObject AmpulPack;
    public Transform NewParent;
    public bool started;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.GetComponent<HeaterGrabAction>())
        {
            gameObject.GetComponents<HeaterGrabAction>()[1].enabled = false;
        }        
        started = false;
        //gameObject.transform.parent = NewParent;
        controller = (controller == null ? GetComponent<VRTK_BaseControllable>() : controller);        
        controller.MaxLimitReached += Controller_MaxLimitReached;
    }

    private void Controller_MaxLimitReached(object sender, ControllableEventArgs e)
    {
        print("MaxReached");
        if (gameObject.GetComponent<VRTK_TrackObjectGrabAttach>())
        {
            gameObject.GetComponent<VRTK_InteractableObject>().grabAttachMechanicScript = gameObject.GetComponent<VRTK_TrackObjectGrabAttach>();
        }
        if (gameObject.GetComponent<VRTK_FixedJointGrabAttach>())
        {
            gameObject.GetComponent<VRTK_InteractableObject>().grabAttachMechanicScript = gameObject.GetComponent<VRTK_FixedJointGrabAttach>();
        }
        if (gameObject.GetComponent<Collider>())
        {
            gameObject.GetComponent<Collider>().enabled = true;
        }
        gameObject.AddComponent<Rigidbody>();
        if (gameObject.name != "AmpulPart")
        {
            AmpulPack.GetComponent<AmpulActivate>().DeletFromList(gameObject);
        }
        started = true;
    }

    public void ActivateInteract()
    {
        if (gameObject.GetComponent<HeaterGrabAction>())
        {
            gameObject.GetComponents<HeaterGrabAction>()[1].enabled = true;
        }

    }

    void SetParent()
    {
        gameObject.transform.parent = NewParent;
    }

    // Update is called once per frame
    void Update()
    {

        if(started)
        {
            SetParent();
            time = +Time.deltaTime;
        }
        if(time > 0.5f)
        {
            Destroy(this);
        }        
    }
}
