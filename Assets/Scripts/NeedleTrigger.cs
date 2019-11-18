using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleTrigger : MonoBehaviour
{
    public Heater_V2 heatControllerl;
    bool Pinned;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Needle")
        {
            if (!Pinned)
            {
                if (heatControllerl.Fixed)
                {
                    if (heatControllerl.Fixed == gameObject.transform.parent.gameObject)
                    {
                        GameObject.FindGameObjectWithTag("Controller").GetComponent<EducationControll>().NeedleIn = true;
                        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("AmpulTriggerZone"))
                        {
                            if (obj.GetComponent<Heater_V2>().Fixed)
                            {
                                obj.GetComponent<Heater_V2>().Fixed.GetComponent<AmpulAtributs>().Heated = true;
                            }
                        }
                    }
                }
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Needle")
        {
            if (!Pinned)
            {
                Pinned = true;
                if (heatControllerl.Fixed)
                {
                    if (heatControllerl.Fixed == gameObject.transform.parent.gameObject)
                    {
                        GameObject.FindGameObjectWithTag("Controller").GetComponent<EducationControll>().NeedleIn = false;
                        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Ampul1"))
                        {
                            obj.GetComponents<HeaterGrabAction>()[0].Heater = null;
                        }
                        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Ampul2"))
                        {
                            obj.GetComponents<HeaterGrabAction>()[0].Heater = null;
                        }
                        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Ampul3"))
                        {
                            obj.GetComponents<HeaterGrabAction>()[0].Heater = null;
                        }
                    }
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Pinned = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
