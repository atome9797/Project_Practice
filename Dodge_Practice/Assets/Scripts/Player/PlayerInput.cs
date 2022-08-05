using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float X { get; private set; }
    public float Y { get; private set; }

    // Update is called once per frame
    void Update()
    {
        X = Y = 0f;

        X = Input.GetAxis("Horizontal");
        Y = Input.GetAxis("Vertical");
    }
}
