using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public Transform sight;

    bool CanSee;

    public float Range = 100.0f;
    private Vector3 heading;
    public bool deactivated;
    public Transform Target;
    public GameObject MovementObj;

    void Update()
    {
        
        RaycastHit[] hits;
        heading = Target.transform.position - gameObject.transform.position;
        sight.transform.LookAt(Target);
        MovementObj.transform.LookAt(Target);
        hits = Physics.RaycastAll(sight.transform.position, heading, Range);
        //print(hits[0].transform.tag);
        if (hits[0].transform.tag == "Player" && deactivated == false)
        {
            MovementObj.GetComponent<Rigidbody>().AddForce(transform.forward * 5);
            //Debug.Log("can see");
            CanSee = false;

        }

        

        

        else
        {

            //Debug.Log("cannot see");
            CanSee = true;

        }

    }
}

