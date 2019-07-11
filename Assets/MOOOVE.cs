using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOOOVE : MonoBehaviour
{
    public float travelSpeed;
    Rigidbody rb;
    public float strength;
    public GameObject joystickgameobject;
    Joystick joystick;
    // Start is called before the first frame update
    void Start()
    {
        joystick = joystickgameobject.GetComponent<Joystick>();
        rb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            if (joystick.Vertical != 0)
            {
            rb.AddForce(Vector3.forward * strength * Time.deltaTime * joystick.Vertical, ForceMode.Force);
            }
            if (joystick.Vertical != 0)
            {
            rb.AddForce(Vector3.right * strength * Time.deltaTime * joystick.Horizontal, ForceMode.Force);
            }

            if (Input.GetKey(KeyCode.W))
            {
            rb.AddForce(Vector3.forward * strength * Time.deltaTime, ForceMode.Force);
            }
            if(Input.GetKey(KeyCode.A))
            {
            rb.AddForce(Vector3.left * strength * Time.deltaTime, ForceMode.Force);
            }
            if(Input.GetKey(KeyCode.S))
            {
            rb.AddForce(Vector3.back * strength * Time.deltaTime, ForceMode.Force);
            }
            if(Input.GetKey(KeyCode.D))
            {
            rb.AddForce(Vector3.right * strength * Time.deltaTime, ForceMode.Force);
            }
    }
}
