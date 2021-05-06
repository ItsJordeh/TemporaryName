using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleEventResetBox : Event
{
    
    public override void PlayEvent()
    {
        
        this.transform.localPosition = new Vector3(-17.8331f, 4.78f, 1.2314f);
        this.transform.rotation.SetLookRotation(new Vector3(0f, 22.515f, 0f));
    }
}
