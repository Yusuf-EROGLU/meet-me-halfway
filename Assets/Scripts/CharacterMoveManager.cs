using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class CharacterMoveManager : MonoBehaviour
{

    private LineRenderer lineRenderer;

    private float range = 20f;

    Vector3 nextPosition;

    
    


    private void Awake()
    {
        SwipeDetector.OnSwipe += Move;
        nextPosition = transform.position;


    }
    // Start is called before the first frame update
    void Update()
    {
        
    }

    // Update is called once per frame
    

    private void Move(SwipeData data)
    {

        //transform.position = transform.position + konum;

        

        switch(data.Direction)
        {

            case SwipeDirection.Up:
                nextPosition = DetectNextPosition(transform.TransformDirection(Vector3.left));
                transform.position = nextPosition;
                
                break;

        }
        

    }

    private Vector3 DetectNextPosition(Vector3 moveDirection)
    {
        RaycastHit obstacle;

        if (Physics.Raycast(transform.position, transform.TransformDirection(moveDirection),out obstacle, range))
        {

            Debug.Log(obstacle.transform.position);
            Vector3 nextDestination;

            //gidilecek yol vektörü
            Vector3 stepSize;

            //karakter ve zombi arası mesafe
            Vector3 distance;

            float absDistanceX;
            float absDistanceZ;
            float absDistanceY;
            

            distance = transform.position - obstacle.transform.position;


            absDistanceX = Math.Abs(distance.x);
            absDistanceZ = Math.Abs(distance.z);
            absDistanceY = Math.Abs(distance.y);


            stepSize.x = distance.x / absDistanceX;
            stepSize.z = distance.z / absDistanceZ;
            stepSize.y = distance.y / absDistanceY;

            nextDestination = obstacle.transform.position + stepSize;

        }

        return new Vector3();
    }
    
}
