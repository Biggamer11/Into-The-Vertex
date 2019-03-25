using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pooler : MonoBehaviour {

    public GameObject pooledObject;
    public GameObject Finish;
    public int poolSize;
    private new Vector3 pos;
    private float Rand;
    public int seedOffset;
    private bool isfirst = true;

    List<GameObject> pool = new List<GameObject>();
    

	// Use this for initialization
	void Start ()
    {
        createPool();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void createPool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            Debug.Log(pos);
            GameObject obj = Instantiate(pooledObject);
            obj.SetActive(false);
            pool.Add(obj);
            GameObject pobj = getPooledObject();
            Rand = Random.Range(0f, 10.0f);

            if (isfirst == true)
            {
                isfirst = false;
            }
            else
            {
                if (Mathf.FloorToInt(Rand) % 2 == 0)
                {
                    pos = pos + new Vector3(pobj.GetComponent<Renderer>().bounds.size.x, 0, 0);
                }
                else
                {
                    pos = pos + new Vector3(0, 0, pobj.GetComponent<Renderer>().bounds.size.z);
                }
                pobj.transform.position = pos;
            }

            if (i >= poolSize - 1)
            {
                Finish.SetActive(true);
                Finish.transform.position = pos;
               
            }

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
