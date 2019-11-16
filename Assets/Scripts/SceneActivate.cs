using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables;
using VRTK;

public class SceneActivate : MonoBehaviour
{
    public VRTK_BaseControllable controller;
    public GameObject Moving;
    public float i;
    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<VRTK_BaseControllable>();
        controller.ValueChanged += Controller_ValueChanged;
    }

    private void Controller_ValueChanged(object sender, ControllableEventArgs e)
    {
        i = e.value;
        if (e.value > -0.5f)
        {
            Moving.SetActive(true);
        }
        else
        {
            Moving.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
