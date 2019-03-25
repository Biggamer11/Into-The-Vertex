using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floating : MonoBehaviour
{
    private Vector3 _startPosition;
    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = _startPosition  + new Vector3(transform.position.x, 0, transform.position.z) + new Vector3(0.0f,(Mathf.Sin(Time.time)*0.05f), 0.0f);
    }
}
