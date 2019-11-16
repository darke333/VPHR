using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables;
using VRTK.Controllables.ArtificialBased;

public class Heater : MonoBehaviour
{
    public VRTK_InteractableObject interact;
    public VRTK_InteractableObject[] Objects;
    public GameObject[] Snap;
    bool[] IsSnapActive;
    // Start is called before the first frame update
    void Start()
    {
        IsSnapActive = new bool[4];
        for (int i = 0; i < 4; i++)
        {
            IsSnapActive[i] = false;
        }
        Snap[0].GetComponent<VRTK_SnapDropZone>().ObjectEnteredSnapDropZone += Heater_ObjectEnteredSnapDropZone1;
        Snap[1].GetComponent<VRTK_SnapDropZone>().ObjectEnteredSnapDropZone += Heater_ObjectEnteredSnapDropZone;
        Snap[2].GetComponent<VRTK_SnapDropZone>().ObjectEnteredSnapDropZone += Heater_ObjectEnteredSnapDropZone2;
        Snap[3].GetComponent<VRTK_SnapDropZone>().ObjectEnteredSnapDropZone += Heater_ObjectEnteredSnapDropZone3;
        Snap[0].GetComponent<VRTK_SnapDropZone>().ObjectExitedSnapDropZone += Heater_ObjectExitedSnapDropZone;
        Snap[1].GetComponent<VRTK_SnapDropZone>().ObjectExitedSnapDropZone += Heater_ObjectExitedSnapDropZone1;
        Snap[2].GetComponent<VRTK_SnapDropZone>().ObjectExitedSnapDropZone += Heater_ObjectExitedSnapDropZone2;
        Snap[3].GetComponent<VRTK_SnapDropZone>().ObjectExitedSnapDropZone += Heater_ObjectExitedSnapDropZone3;
    }

    private void Heater_ObjectExitedSnapDropZone3(object sender, SnapDropZoneEventArgs e)
    {
        IsSnapActive[3] = false;
    }

    private void Heater_ObjectExitedSnapDropZone2(object sender, SnapDropZoneEventArgs e)
    {
        IsSnapActive[2] = false;
    }

    private void Heater_ObjectExitedSnapDropZone1(object sender, SnapDropZoneEventArgs e)
    {
        IsSnapActive[1] = false;
    }

    private void Heater_ObjectExitedSnapDropZone(object sender, SnapDropZoneEventArgs e)
    {
        IsSnapActive[0] = false;
    }

    private void Heater_ObjectEnteredSnapDropZone3(object sender, SnapDropZoneEventArgs e)
    {
        IsSnapActive[3] = true;
    }

    private void Heater_ObjectEnteredSnapDropZone2(object sender, SnapDropZoneEventArgs e)
    {
        IsSnapActive[2] = true;
    }

    private void Heater_ObjectEnteredSnapDropZone1(object sender, SnapDropZoneEventArgs e)
    {
        IsSnapActive[0] = true;
    }

    private void Heater_ObjectEnteredSnapDropZone(object sender, SnapDropZoneEventArgs e)
    {
        IsSnapActive[1] = true;
    }


    // Update is called once per frame
    void Update()
    {

        if (interact.IsGrabbed())
        {
            for(int i = 0; i < 4; i++)
            {
                if (Objects[i].IsGrabbed() || IsSnapActive[i])
                {
                    Snap[i].SetActive(true);
                }
                else
                {
                    Snap[i].SetActive(false);
                }
            }
        }
    }
}
