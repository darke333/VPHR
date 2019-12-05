using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables;

public class PumpWork : MonoBehaviour
{
    VRTK_BaseControllable controllable;
    public int count;
    public int Number;
    public EducationControll educ;
    public AmpulAtributs Ampul;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        controllable = (controllable == null ? GetComponent<VRTK_BaseControllable>() : controllable);
        controllable.MaxLimitReached += Controllable_MaxLimitReached;
        controllable.MinLimitReached += Controllable_MinLimitReached;
    }

    void OnEnable()
    {
        count = 0;
    }

    private void Controllable_MinLimitReached(object sender, ControllableEventArgs e)
    {
        count++;
        if (count == educ.countTimes)
        {
            educ.END = true;
            Ampul.SetMaterial();
            if(Ampul.tag == "Ampul3")
            {
                foreach (GameObject ampul in GameObject.FindGameObjectsWithTag("Ampul3"))
                {
                    AmpulAtributs atributs = ampul.GetComponent<AmpulAtributs>();
                    if (atributs.EndRemoved == 2 && !atributs.EndPinned)
                    {
                        atributs.SetMaterial(0);
                    }
                }
            }
        }
    }

    private void Controllable_MaxLimitReached(object sender, ControllableEventArgs e)
    {
        print("Max");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
