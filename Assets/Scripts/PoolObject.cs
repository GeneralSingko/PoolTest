using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    public static PoolObject SharedInstance;
    public List<GameObject> PoolObjects;
    public GameObject ObjectstoPool;
    public int AmountToPool;
    private void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        //create the pool objects
        PoolObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < AmountToPool; i++)
        {
            tmp = Instantiate(ObjectstoPool);
            tmp.SetActive(false);
            PoolObjects.Add(tmp);
        }

    }

    //Get the pool Items
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < AmountToPool; i++)
        {
            if (!PoolObjects[i].activeInHierarchy)
            {
                return PoolObjects[i];
            }
        }
        return null;
    }

    void UsePooledObject()
    {
        GameObject pooledObject = GetPooledObject();
        if (pooledObject != null)
        {
            pooledObject.SetActive(true);
            // do something with the object
            pooledObject.transform.position = new Vector3(0, 0, 0); // Example: reset object's position
            pooledObject.GetComponent<PoolObject>(); // Example: call a method on the object's component
            AddToPool(pooledObject); // Return the object to the pool for later reuse
        }
    }

    void AddToPool(GameObject pooledObject)
    {
        pooledObject.SetActive(false);
        // Reset any other necessary object properties
        // (e.g. set health to full, hide any visual effects, etc.)
        // before returning the object to the pool.
    }


}
