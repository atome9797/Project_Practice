using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bullet;
    public float time = 0f;
    GameObject player = GameObject.Find("Player");

   

    void Update()
    {
        time += Time.deltaTime;
        if (time > 3f)
        {
            time = 0f;
            Instantiate(bullet, transform);
            bullet.transform.LookAt(player.transform);
        }
    }

}
