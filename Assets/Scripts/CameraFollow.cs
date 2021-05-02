using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public InputHandler _input;

    private Camera cam;
    public Transform center;
    public Vector3 axis = Vector3.up;
    public Vector3 desiredPosition;
    public float radius = 2f;
    
    private float currentZoom = 0f;
    public float rotationSpeed = 80.0f;

    public float zoomSens = 15.0f;
    public float zoomSpeed = 5.0f;
    public float zoomMin = 19.0f;
    public float zoomMax = 50.0f;

    private float zoom;

    Vector3 offset;
    void Start()
    {
        
        center = target.transform; // Determine center of object as orbit point
        transform.position = (transform.position - center.position).normalized * radius + center.position;
        cam = GetComponent<Camera>();
        zoom = cam.fieldOfView;
    }

    // Update is called once per frame
    float travel;
    float scrollSpeed = 3;
    void Update()
    {
        // desiredPosition = (transform.position - center.position).normalized * radius + center.position;
        if(_input.LeftRotation)
        {
            
            transform.RotateAround(center.position, -axis, rotationSpeed * Time.deltaTime);
        }
        if(_input.RightRotation)
        {
            transform.RotateAround(center.position, axis, rotationSpeed * Time.deltaTime);
        }

         var d = Input.GetAxis("Mouse ScrollWheel");
         if (d > 0f && travel > zoomMin)
         {
             travel = travel - scrollSpeed;
             Camera.main.transform.Translate(0, 0, 1 * scrollSpeed, Space.Self);
         }
         else if (d < 0f && travel < zoomMax)
         {
             travel = travel + scrollSpeed;
             Camera.main.transform.Translate(0, 0, -1 * scrollSpeed, Space.Self);
         }
        // zoom = _input.ScrollWheel * zoomSens;
        // zoom = Mathf.Clamp(zoom, zoomMin, zoomMax);
            
        //desiredPosition = (transform.position - center.position).normalized * radius + center.position;
        //transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
    }
    void LateUpdate()
    {
        
        
        
    }
}
