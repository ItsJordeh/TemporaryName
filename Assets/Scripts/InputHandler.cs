using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{

    public float sensitivity= 5f;
    public Vector3 InputVector{get; private set;}

    public Vector2 MousePosition{get; private set;}

    public bool LeftRotation;
    public bool RightRotation;
    public bool UpArrow;
    public bool DownArrow;

    public float ScrollWheel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        InputVector = new Vector2(h, v);
        if(Input.GetKey(KeyCode.Q)) LeftRotation = true; else LeftRotation = false;
        if(Input.GetKey(KeyCode.E)) RightRotation = true; else RightRotation = false;
        if(Input.GetKey(KeyCode.UpArrow)) UpArrow = true; else UpArrow = false;
        if(Input.GetKey(KeyCode.DownArrow)) DownArrow = true; else DownArrow = false;

        ScrollWheel = Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        
        MousePosition = Input.mousePosition; 

    }
}
