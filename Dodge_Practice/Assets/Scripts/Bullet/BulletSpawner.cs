using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float time = 0f;
    GameObject player;


    void Update()
    {
        player = GameObject.Find("Player");
        time += Time.deltaTime;
        if (time > 3f)
        {
            time = 0f;
            GameObject bullet = Instantiate(BulletPrefab, transform); //���� ������Ʈ ����
            bullet.transform.LookAt(player.transform);
        }
    }

}
