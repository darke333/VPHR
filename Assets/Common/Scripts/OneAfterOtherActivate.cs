using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class OneAfterOtherActivate : MonoBehaviour
{
    [SerializeField] List<Collider> ListOfColliders;
    int CurrentNumber;

    // Start is called before the first frame update
    void Start()
    {
        CurrentNumber = 0;
        ListOfColliders[CurrentNumber].enabled = true;
        //Activation();
    }

    public void Activation(GameObject sender)    
    {
        if(CurrentNumber < ListOfColliders.Count && ListOfColliders[CurrentNumber] == sender.GetComponent<Collider>())
        {
            CurrentNumber++;
            ListOfColliders[CurrentNumber].enabled = true;
        }
    }

}
