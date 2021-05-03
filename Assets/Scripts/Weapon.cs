using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    private WeaponHandler handler;
    
    void Start()
    {
        handler = GetComponentInParent<WeaponHandler>();
    }
    public void ResetCooldowns()
    {
        handler.ResetCooldowns();
    }
}
