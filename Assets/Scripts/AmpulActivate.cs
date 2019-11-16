using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class AmpulActivate : MonoBehaviour
{
    VRTK_InteractableObject controller;
    public Transform Ampuls;
    public List<GameObject> AmpulObjects;
    public bool Active;
    // Start is called before the first frame update
    void Start()
    {
        controller = (controller == null ? GetComponent<VRTK_InteractableObject>() : controller);
        Active = false;
        controller.InteractableObjectGrabbed += Controller_InteractableObjectGrabbed;
        controller.InteractableObjectUngrabbed += Controller_InteractableObjectUngrabbed;
        foreach (GameObject Ampul in GameObject.FindGameObjectsWithTag(Ampuls.name))
        {
            AmpulObjects.Add(Ampul);
        }
        foreach (GameObject Ampul in AmpulObjects)
        {
            if (Ampul.GetComponent<Collider>())
            {
                Ampul.GetComponent<Collider>().enabled = false;
            }

        }
    }

    private void Controller_InteractableObjectUngrabbed(object sender, InteractableObjectEventArgs e)
    {
        FirstActivateAmpulFunc(false);
    }

    private void Controller_InteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
    {

        FirstActivateAmpulFunc(true);
    }

    // Update is called once per frame
    /*void Update()
    {
        if (!Active)
        {
            if (!gameObject.GetComponent<FixedJoint>())
            {
                Active = true;
            }
        }
    }*/

    public void FirstActivateAmpulFunc(bool enable)
    {
        foreach (GameObject Ampul in AmpulObjects)
        {
            if (Ampul.GetComponent<Collider>())
            {
                Ampul.GetComponent<Collider>().enabled = enable;
            }
            if (Ampul.transform.Find("Right"))
            {
                Ampul.transform.Find("Right").GetComponent<Collider>().enabled = true;
                Ampul.transform.Find("Wrong").GetComponent<Collider>().enabled = true;
            }
            else
            {
                Ampul.transform.Find("Wrong1").GetComponent<Collider>().enabled = true;
                Ampul.transform.Find("Wrong").GetComponent<Collider>().enabled = true;
            }
            if (gameObject.name != "AmpulPart")
            {

            }
        }
        /*if (Active)
        {
            foreach (GameObject Ampul in AmpulObjects)
            {
                if (Ampul.GetComponent<Collider>())
                {
                    Ampul.GetComponent<Collider>().enabled = enable;
                }                
            }
        }*/
    }
    
    public void DeletFromList(GameObject deleted)
    {
        AmpulObjects.Remove(deleted);
    }
}
