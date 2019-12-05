using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables;
using VRTK.Controllables.ArtificialBased;

public class TriggerZoneControll : MonoBehaviour
{
    public GameObject[] PAmpulPacks;
    public GameObject[] HAmpulPacks;
    public VRTK_BaseControllable AmpulHolder;
    public GameObject PAmpulPack;
    public GameObject HAmpulPack;
    public float HolderRotation;
    public bool AmpulPackIn;
    public VRTK_InteractableObject controller;
    int i;
    

    protected virtual void OnEnable()
    {
        for(int i = 0; i < 3; i++)
        {
            PAmpulPacks[i].SetActive(false);
            HAmpulPacks[i].SetActive(false);
        }
        AmpulHolder.ValueChanged += AmpulHolder_ValueChanged;
    }


    private void AmpulHolder_ValueChanged(object sender, ControllableEventArgs e)
    {
        HolderRotation = e.value;
    }

    void Start()
    {
        i = 0;
        PAmpulPack = PAmpulPacks[i];
        controller = PAmpulPack.transform.parent.gameObject.GetComponent<VRTK_InteractableObject>();
        HAmpulPack = HAmpulPacks[i];
        HAmpulPack.SetActive(false);
        PAmpulPack.SetActive(false);

        AmpulPackIn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.IsGrabbed())
        {
            if (PAmpulPack.transform.parent.gameObject.GetComponent<Rigidbody>())
            {
                if (!HAmpulPack.transform.parent.gameObject.GetComponent<Rigidbody>())
                {
                    HAmpulPack.SetActive(true);
                    PAmpulPack.SetActive(true);
                    HAmpulPack.transform.parent.gameObject.GetComponent<AmpulActivate>().enabled = true;
                    GameObject.FindGameObjectWithTag("Controller").GetComponent<EducationControll>().AmpulPackReleased(i);
                    ++i;
                    if (i < 3)
                    {                        
                        PAmpulPack = PAmpulPacks[i];
                        controller = PAmpulPack.transform.parent.gameObject.GetComponent<VRTK_InteractableObject>();
                        HAmpulPack = HAmpulPacks[i];
                    }
                    else
                    {
                        Destroy(this.gameObject);
                    }
                    
                }
            }
            else
            {
                //PAmpulPack.transform.parent.gameObject.AddComponent<Rigidbody>();
            }
        }
        
        if(HolderRotation > 0)
        {
            PAmpulPack.SetActive(false);
        }
        else
        {
            PAmpulPack.SetActive(true);
        }
    }

}
