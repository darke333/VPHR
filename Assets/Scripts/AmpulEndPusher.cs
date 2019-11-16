using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmpulEndPusher : MonoBehaviour
{
    public string AmpulTag;
    public EndRemove[] Breakers;
    void Start()
    {
        if(gameObject.name == "GreenTrigger")
        {
            AmpulTag = "Ampul1";
        }
        if (gameObject.name == "RedTrigger")
        {
            AmpulTag = "Ampul3";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RightEnd")
        {
            if (other.transform.parent.tag == AmpulTag)
            {
                bool t = false;
                foreach(EndRemove end in Breakers)
                {
                    foreach(Collider col in end.Colis)
                    {
                        if(col == other)
                        {
                            t = true;
                        }
                    }
                }
                if (t)
                {
                    other.transform.parent.GetComponent<AmpulAtributs>().EndPinned = true;
                    GameObject.FindGameObjectWithTag("Controller").GetComponent<EducationControll>().AmpulPrepeared = true;
                }
            }
        }
        print("Released");
    }

    void Update()
    {
        
    }
}
