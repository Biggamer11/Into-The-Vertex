using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class counter : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(GameManager.instance.GetScore() == 0)
        {
            gameObject.GetComponent<Text>().text = "0 / 3";
        }
        if (GameManager.instance.GetScore() == 1)
        {
            gameObject.GetComponent<Text>().text = "1 / 3";
        }
        if (GameManager.instance.GetScore() == 2)
        {
            gameObject.GetComponent<Text>().text = "2 / 3";
        }
        if (GameManager.instance.GetScore() == 3)
        {
            gameObject.GetComponent<Text>().text = "3 / 3";
        }
    }
}
