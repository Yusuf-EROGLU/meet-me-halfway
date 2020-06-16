using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnBarrel : MonoBehaviour
{
    public float spinSpeedX;
    public float spinSpeedY;
    public float spinSpeedZ;
    
    // Update is called once per frame
    void Update()
    {

        transform.Rotate(spinSpeedX, spinSpeedY, spinSpeedZ * Time.deltaTime, Space.World);
    }
}