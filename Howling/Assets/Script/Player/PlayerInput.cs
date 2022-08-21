using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float X { get; private set; }
    public float Y { get; private set; }
    public float mouseX { get; private set; }
    public float mouseY { get; private set; }
    
    public bool CanPickup { get; private set; }
    public bool CanSitDown { get; private set; }

    

    // Update is called once per frame
    void Update()
    {
        X = Y = mouseX = mouseY = 0f;
        X = Input.GetAxis("Vertical");
        Y = Input.GetAxis("Horizontal");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        CanPickup = Input.GetMouseButton(0);
        CanSitDown = Input.GetKey(KeyCode.LeftControl);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);
    }
}
