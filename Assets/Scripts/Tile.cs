using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tile : MonoBehaviour
{

    public GameObject pooledObject;
    public int x, z;
    private new Vector3 pos;

    List<GameObject> pool = new List<GameObject>();


    // Use this for initialization
    void Start()
    {
        createPool();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void createPool()
    {
        for (int i = 0; i < x; i++)
        {
            Debug.Log(pos);
            GameObject obj = Instantiate(pooledObject);
            obj.SetActive(false);
            pool.Add(obj);
            GameObject pobj = getPooledObject();
            pos = pos + new Vector3(pobj.GetComponent<Renderer>().bounds.size.x, 0, 0);
            
            obj.SetActive(true);
        }
    }



    public GameObject getPooledObject()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (pool[i] != null && !pool[i].activeSelf)
            {
                return pool[i];
            }
        }
        return null;
    }
}
