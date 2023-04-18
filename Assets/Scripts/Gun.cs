using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform BulletSpawnpoint;
    public GameObject BulletPrefab;
    public float BulletSpeed;
    public GameObject SpawnFX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(SpawnFX, BulletSpawnpoint.position, BulletSpawnpoint.rotation);
            var bullet = Instantiate(BulletPrefab, BulletSpawnpoint.position, BulletSpawnpoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = BulletSpawnpoint.forward * BulletSpeed;
        }
    }
}
