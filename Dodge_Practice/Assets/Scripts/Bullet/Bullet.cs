using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    
    void Start()
    {
        Destroy(gameObject, 5f);        
    }

    void Update()
    {
        
        transform.Translate(0f, 0f, speed * Time.deltaTime);   
    }
}
