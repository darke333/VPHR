using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRemove : MonoBehaviour
{
    public Transform NewParent;
    public List<Collider> Colis;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RightEnd" || other.tag == "LeftEnd")
        {
            if (!other.GetComponent<Rigidbody>())
            {
                bool t = false;
                foreach (Collider col in Colis)
                {
                    if(col == other)
                    {
                        t = true;
                    }
                }
                if (!other.transform.parent.GetComponent<AmpulAtributs>().Heated)
                {
                    t = true;
                }
                if (!t)
                {
                    GameObject newobj = Instantiate(other.gameObject, other.transform.position, other.transform.rotation, NewParent);
                    other.transform.parent.GetComponent<AmpulAtributs>().EndRemoved++;
                    newobj.AddComponent<Rigidbody>();
                    Colis.Add(other);
                    if (other.transform.parent.tag == "Ampul2")
                    {
                        if (other.name == "Wrong")
                        {
                            Collider col = other.transform.parent.Find("Wrong1").GetComponent<Collider>();
                            foreach(Collider coli in Colis)
                            {
                                if (col == coli)
                                {
                                    GameObject.FindGameObjectWithTag("Controller").GetComponent<EducationControll>().AmpulPrepeared = true;
                                }
                            }
                        }
                        if (other.name == "Wrong1")
                        {
                            Collider col = other.transform.parent.Find("Wrong").GetComponent<Collider>();
                            foreach (Collider coli in Colis)
                            {
                                if (col == coli)
                                {
                                    GameObject.FindGameObjectWithTag("Controller").GetComponent<EducationControll>().AmpulPrepeared = true;
                                }
                            }
                        }
                    }
                }
                
                //other.isTrigger = true;
            }
        }
        print("Released");
    }
}
