using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float maxSpeed;
    private Vector3 startpos;
    private bool jump = false;
    
    // Start is called before the first frame update
    void Start()
    {
        startpos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.D))
        {
            
            if (rb.velocity.x < maxSpeed)
            {
                rb.AddForce(new Vector3(speed, 0, 0));
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            
            if (rb.velocity.x > -maxSpeed)
            {
                rb.AddForce(new Vector3(-speed, 0, 0));
            }

        }

        if (Input.GetKey(KeyCode.W))
        {
            
            if (rb.velocity.z < maxSpeed)
            {
                rb.AddForce(new Vector3(0, 0, speed));
            }

        }

        if (Input.GetKey(KeyCode.S))
        {
            
            if (rb.velocity.z > -maxSpeed)
            {
                rb.AddForce(new Vector3(0, 0, -speed));
            }

        }

        if (Input.GetKey(KeyCode.Space))
        {
            

            if (jump == false && rb.velocity.y == 0)
            {
                rb.velocity = new Vector3(0,speed * 0.6f,0);
                jump = true;
            }

            else if (rb.velocity.y == 0)
            {
                jump = false;
            }
        }

        if (transform.position.y < -10)
        {
            transform.position = startpos;
            rb.velocity = new Vector3(0,0,0);
            GameManager.instance.DecLives();
            Debug.Log("die");
        }

        
    }

    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "End")
        {
            GameManager.instance.LoadScene("Stage 1");
        }

        if (collision.collider.tag  == "Enemy")
        {
            Debug.Log("Hit");
            transform.position = startpos;
            rb.velocity = new Vector3(0, 0, 0);
            GameManager.instance.DecLives();
            
        }

        if (collision.collider.tag == "Green Circuit")
        {
            Debug.Log("Green Circuit");
            collision.gameObject.SetActive(false);
            GameManager.instance.IncGreen();

        }

        if (collision.collider.tag == "Red Circuit")
        {
            Debug.Log("Red Circuit");
            collision.gameObject.SetActive(false);
            GameManager.instance.IncRed();
        }

        if (collision.collider.tag == "Blue Circuit")
        {
            Debug.Log("Blue Circuit");
            collision.gameObject.SetActive(false);
            GameManager.instance.IncBlue();

        }
    }
}
