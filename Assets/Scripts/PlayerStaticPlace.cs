using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStaticPlace : MonoBehaviour
{
    public Transform StartPosition;
    public Transform Head;
    // Start is called before the first frame update
    void Start()
    {
        Head.position = StartPosition.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("k"))
        {
            Head.position = StartPosition.position;
        }
    }
}
