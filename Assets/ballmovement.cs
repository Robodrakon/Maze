using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ballmovement : MonoBehaviour

{
    public GameObject sphere;
    Rigidbody rb;
    public float strength;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * strength, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * strength, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-Vector3.forward * strength, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * strength, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * strength, ForceMode.Force);
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            rb.AddForce(Vector3.forward * strength * Input.GetAxis("Vertical"), ForceMode.Force);
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            rb.AddForce(Vector3.right * strength * Input.GetAxis("Horizontal"), ForceMode.Force);
        }
    }
}
