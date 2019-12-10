using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsOnTriggers : MonoBehaviour
{

    [SerializeField] UnityEvent TriggerExit;
    [SerializeField] UnityEvent TriggerEnter;
    [SerializeField] UnityEvent TriggerStay;
    public string TargetTag;
    public GameObject TargetObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Check(TriggerEnter, other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        Check(TriggerExit, other.gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        Check(TriggerStay, other.gameObject);
    }

    void Check(UnityEvent unityEvent, GameObject other)
    {
        if (TargetObject)
        {
            if (other == TargetObject)
            {
                unityEvent.Invoke();
            }
        }
        if (other.tag != "")
        {
            if (other.tag == TargetTag)
            {
                unityEvent.Invoke();
            }
        }
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
