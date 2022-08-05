using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerInput input;
    public Rigidbody rigidbody;
    public float PlayerSpeed = 10f;

    void Start()
    {
        input = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity =  new Vector3(PlayerSpeed * input.X, 0f, PlayerSpeed * input.Y);
    }
}
