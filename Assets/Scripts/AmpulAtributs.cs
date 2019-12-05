using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmpulAtributs : MonoBehaviour
{
    public MeshRenderer mesh;
    public int EndRemoved;
    public bool Heated;
    public bool EndPinned;
    public Material HighDColor;
    public Material LowDColor;
    public Material MidDColor;
    public Material NormalDanger;
    public bool Using;

    // Start is called before the first frame update
    void Start()
    {
        Using = false;
        mesh = transform.Find("Indicator").GetComponent<MeshRenderer>();
        //transform.Find("Indicator").GetComponent<MeshRenderer>().material = NormalDanger;
        EndRemoved = 0;
        if (gameObject.tag == "Ampul2")
        {
            EndPinned = true;
        }
        else
        {
            EndPinned = false;
        }
    }

    public void SetMaterial(int i = -1)
    {
        if(i == -1)
        {
            i = GameObject.FindGameObjectWithTag("Controller").GetComponent<EducationControll>().DangerLevel;
        }
        switch (i)
        {
            case 1:
                transform.Find("Indicator").GetComponent<MeshRenderer>().material = LowDColor;
                if (gameObject.tag == "Ampul3")
                {
                    transform.Find("Indicator").GetComponent<MeshRenderer>().material = HighDColor;
                }
                break;
            case 2:
                transform.Find("Indicator").GetComponent<MeshRenderer>().material = MidDColor;
                if (gameObject.tag == "Ampul3")
                {
                    transform.Find("Indicator").GetComponent<MeshRenderer>().material = HighDColor;
                }
                break;
            case 3:
                transform.Find("Indicator").GetComponent<MeshRenderer>().material = HighDColor;
                if (gameObject.tag == "Ampul3")
                {
                    transform.Find("Indicator").GetComponent<MeshRenderer>().material = HighDColor;
                }
                break;
            case 0:
                transform.Find("Indicator").GetComponent<MeshRenderer>().material = NormalDanger;
                if (gameObject.tag == "Ampul3")
                {
                    transform.Find("Indicator").GetComponent<MeshRenderer>().material = NormalDanger;
                }
                break;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
