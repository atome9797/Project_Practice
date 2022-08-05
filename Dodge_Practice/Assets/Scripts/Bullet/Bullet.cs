using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Transform transform;
    
    void Start()
    {
        transform = GetComponent<Transform>();
        Destroy(gameObject, 5f);        
    }

    void Update()
    {
        
        transform.Translate(0f, 0f, speed * Time.deltaTime);   
    }
}
