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
        GameObject PoolObjects = GetPooledObject();
        if (PoolObjects != null)
        {
            PoolObjects.SetActive(true);
            // do something with the object
            PoolObjects.SetActive(false);
        }

    }

}
