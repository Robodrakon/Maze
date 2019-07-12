using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MovePlayer : MonoBehaviour
{
    public float speed;
    public Vector3 calibration_offset;
    public float sensitivity;
    Vector2 azimuthal; //for 2d forward/side look dir in xz plane, 0,1 is forward
    Vector2 altitude; //for this yz plane , 0,1 is forward
    public float deadzone;
    // Start is called before the first frame update
    void Start()
    {
        azimuthal = new Vector2( transform.forward.x , transform.forward.z);
        altitude = new Vector2( transform.forward.y , transform.forward.z);
    }

    void recalibrate()
    {
        calibration_offset = Vector3.down - Input.acceleration;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Rigidbody Rb = GetComponent<Rigidbody>();
        //if(Input.GetAxis("Horizontal")!=0)
        //    Rb.MovePosition( Rb.position + transform.right * Input.GetAxis("Horizontal") * speed*Time.deltaTime);
        //if(Input.GetAxis("Vertical")!=0)
        //    Rb.MovePosition(Rb.position + transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime);
        //printout(new Vector2( Input.GetAxis("Horizontal"), Input.GetAxis("Vertical") ).ToString());
        //printout(Input.acceleration.ToString());

        if(Input.acceleration != Vector3.zero)
        {
            //transform.RotateAround(transform.position,Vector3.up,Input.acceleration.x * sensitivity);
            Vector3 prior = transform.forward;
            Vector3 acc = Input.acceleration + calibration_offset;
            altitude.x = acc.z; altitude.y  = -acc.y; 
            float rotate = sensitivity * Input.acceleration.x * Time.deltaTime;
            rotate *= -1;//tilt control
            if(Mathf.Abs(rotate) < deadzone) rotate = 0;
            azimuthal.x  = azimuthal.x * Mathf.Cos(rotate) - azimuthal.y * Mathf.Sin(rotate);
            azimuthal.y = Mathf.Sin(rotate) * azimuthal.x + Mathf.Cos(rotate) * azimuthal.y;
            azimuthal.Normalize();

            transform.forward = new Vector3 (azimuthal.x, 0 , azimuthal.y);
            transform.RotateAround(transform.position,transform.right,-Mathf.Rad2Deg*Mathf.Atan2(altitude.x,altitude.y));

            //transform.forward = new Vector3(prior.x,acc.z,-acc.y);
        }
        
          
    }


    void printout(string tex)
    {
        GameObject.Find("MessageText2").GetComponent<Text>().text = tex;
    }
}
