using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifebar : MonoBehaviour
{
    public int numlife;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (numlife == GameManager.instance.GetLives())
        {
            gameObject.SetActive(false);
        }
    }
}
