using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using VRTK;

public class SnapOnPos : MonoBehaviour
{
    [SerializeField] Material TriggerMaterial;
    [SerializeField] GameObject TargetObject;
    [SerializeField] string TargetTag;
    [SerializeField] Transform Parent;
    [SerializeField] Rigidbody ConnectToBody;
    [SerializeField] float ConnectedForce = 100;
    public GameObject PlacedObject;
    [SerializeField] UnityEvent EnteredSnap;
    [SerializeField] UnityEvent PlacedONSnap;
    //[SerializeField] UnityEvent StayOnSnap;
    [SerializeField] UnityEvent OutOfSnap;
    [HideInInspector] public bool IsFilled;


    // Start is called before the first frame update
    void Start()
    {
        IsFilled = false;
        gameObject.GetComponent<MeshRenderer>().material = TriggerMaterial;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;

    }
    private void OnEnable()
    {
        if (ConnectToBody)
        {
            foreach (Collider collider in ConnectToBody.GetComponents<Collider>())
            {
                Physics.IgnoreCollision(collider, gameObject.GetComponent<Collider>());
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (TargetObject)
        {
            if (other.gameObject == TargetObject)
            {
                EnterSnap(other.gameObject);
            }
        }
        if (other.tag != "")
        {
            if (other.tag == TargetTag)
            {
                EnterSnap(other.gameObject);
            }
        }
    }

    void EnterSnap(GameObject other)
    {
        PlacedObject = other;
        EnteredSnap.Invoke();
    }

    public void SerachedObjectGrabbed()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        gameObject.GetComponent<Collider>().enabled = true;
    }

    public void SerachedObjectUnGrabbed()
    {
        Snaping();
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;

    }

   void Snaping()
    {
        if (PlacedObject)
        {
            PlacedObject.transform.position = gameObject.transform.position;
            PlacedObject.transform.rotation = gameObject.transform.rotation;
            if (ConnectToBody)
            {
                PlacedObject.AddComponent<FixedJoint>().connectedBody = ConnectToBody;
                PlacedObject.GetComponent<FixedJoint>().breakForce = ConnectedForce;
            }
            if (Parent)
            {
                transform.parent = Parent;
            }
            PlacedONSnap.Invoke();
            IsFilled = true;
        }
    }

    /*private void OnTriggerStay(Collider other)
    {
        if (PlacedObject)
        {
            if (other.gameObject == PlacedObject)
            {
                StayOnSnap.Invoke();
            }
        }
    }*/

    private void OnTriggerExit(Collider other)
    {
        if (PlacedObject)
        {
            if (TargetObject)
            {
                if (other.gameObject == TargetObject)
                {
                    PlacedObject = null;
                    OutOfSnap.Invoke();
                    IsFilled = false;
                }
            }
            if (other.tag != "")
            {
                if (other.tag == TargetTag)
                {
                    PlacedObject = null;
                    OutOfSnap.Invoke();
                    IsFilled = false;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
