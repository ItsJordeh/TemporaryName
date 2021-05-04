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
    public bool RKey;
    public bool LMB;
    public bool RMB;

    
    public bool doubleTapW, doubleTapA, doubleTapS, doubleTapD;
    

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
        if(Input.GetKey(KeyCode.R)) RKey = true; else RKey = false;
        if(Input.GetMouseButton(0)) LMB = true; else LMB = false;
        if(Input.GetMouseButton(1)) RMB = true; else RMB = false;
        DetectDoubleTap();

        


        ScrollWheel = Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        
        MousePosition = Input.mousePosition; 

    }
    public float doubleTapCooldown = 0.3f;
    private float timeWPressed, timeAPressed, timeSPressed, timeDPressed;
    void DetectDoubleTap() //The public double tap variables must be reset when they are used within the player controller
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            if(Time.time < timeWPressed + doubleTapCooldown && doubleTapW == false)
            {
                doubleTapW = true;
            }
            else if(Time.time > timeWPressed + doubleTapCooldown)
            {
                doubleTapW = false;
            }
            timeWPressed = Time.time;
            
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            if(Time.time < timeAPressed + doubleTapCooldown && doubleTapA == false)
            {
                doubleTapA = true;
            }
            else if(Time.time > timeAPressed + doubleTapCooldown)
            {
                doubleTapA = false;
            }
            timeAPressed = Time.time;
            
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            if(Time.time < timeSPressed + doubleTapCooldown && doubleTapS == false)
            {
                doubleTapS = true;
            }
            else if(Time.time > timeSPressed + doubleTapCooldown)
            {
                doubleTapS = false;
            }
            timeSPressed = Time.time;
            
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            if(Time.time < timeDPressed + doubleTapCooldown && doubleTapD == false)
            {
                doubleTapD = true;
            }
            else if(Time.time > timeDPressed + doubleTapCooldown)
            {
                doubleTapD = false;
            }
            timeDPressed = Time.time;
            
        }
    }
    public void ResetDoubleTaps()
    {
        doubleTapW = false;doubleTapA = false; doubleTapS = false; doubleTapD = false;

    }
}
