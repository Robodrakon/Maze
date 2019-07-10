using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public GameObject target;
    Vector3 moveTowards;
    public float lerpFactor;
    Vector3 lastPosition;
    //Start is called before the first frame update
     void Start()
    {
        //initialOffset =target.transform.position-transform.position;
        lastPosition = target.transform.position;
        moveTowards = transform.position;
    }

    //update once per frame 
    void LateUpdate()
    {
        moveTowards += target.transform.position - lastPosition;
        lastPosition = target.transform.position;
        transform.position = Vector3.Lerp(transform.position,
            moveTowards, lerpFactor);
    }
}