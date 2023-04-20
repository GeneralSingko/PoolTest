using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform BulletSpawnpoint;
    public GameObject BulletPrefab;
    public float BulletSpeed;
    public GameObject SpawnFX;
    
    public float lifetime = 2f;
    private float timer;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject BulletPrefab = PoolObject.SharedInstance.GetPooledObject();
            if (BulletPrefab != null)
            {
                BulletPrefab.transform.position = BulletSpawnpoint.transform.position;
                BulletPrefab.transform.rotation = BulletSpawnpoint.transform.rotation;
                BulletPrefab.GetComponent<Rigidbody>().velocity =
                BulletSpawnpoint.forward * BulletSpeed;
                BulletPrefab.SetActive(true);
            }
        }

        /*if (timer >= lifetime)
        {
            ObjectPool.Instance.ReturnBullet(gameObject);
        }*/
    }
}
