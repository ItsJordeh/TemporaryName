using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    private InputHandler _input;
    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponentInParent<InputHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
