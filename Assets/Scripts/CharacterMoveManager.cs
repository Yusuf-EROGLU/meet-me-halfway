using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class CharacterMoveManager : MonoBehaviour
{

    private float range = 7f;

    Vector3 nextPosition;

    public Transform startposition;

    // Movement speed in units per second.
    public float speed = 0.5f;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;





    private void Awake()
    {
        SwipeDetector.OnSwipe += Move;
        nextPosition = transform.position;

    }
    // Start is called before the first frame update
    void Update()
    {
        if (nextPosition != transform.position) { 
        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        transform.position = Vector3.Lerp(startposition.position, nextPosition, fractionOfJourney);
        }
    }

    // Update is called once per frame
    

    private void Move(SwipeData data)
    {

        //transform.position = transform.position + konum;

        startTime = Time.time;
        startposition = transform;

        switch (data.Direction)
        {
            
            case SwipeDirection.Up:
                if (this.tag.Equals("Male"))            nextPosition = DetectNextPosition(transform.TransformDirection(Vector3.right));
                else if (this.tag.Equals("Female"))     nextPosition = DetectNextPosition(transform.TransformDirection(Vector3.left));
                   // transform.position = nextPosition;
                break;
            case SwipeDirection.Down:
                if (this.tag.Equals("Male"))            nextPosition = DetectNextPosition(transform.TransformDirection(Vector3.left));
                else if (this.tag.Equals("Female"))     nextPosition = DetectNextPosition(transform.TransformDirection(Vector3.right));
               // transform.position = nextPosition;
                break;
            case SwipeDirection.Left:
                nextPosition = DetectNextPosition(transform.TransformDirection(Vector3.back));
               // transform.position = nextPosition;
                break;
            case SwipeDirection.Right:
                nextPosition = DetectNextPosition(transform.TransformDirection(Vector3.forward));
             //   transform.position = nextPosition;
                break;

        }


        journeyLength = Vector3.Distance(transform.position, nextPosition);
    }

    private Vector3 DetectNextPosition(Vector3 moveDirection)
    {
        RaycastHit obstacle;
        Vector3 nextDestination = new Vector3();

        if (Physics.Raycast(transform.position, transform.TransformDirection(moveDirection),out obstacle, range, 1))
        {
            Vector3 distanceToObstacle = new Vector3(0,0,0);
            Vector3 distance;

            float absDistanceX;
            float absDistanceZ;
            float absDistanceY;
            
            distance = transform.position - obstacle.transform.position;

            Debug.Log(distance + "mesafe");
            absDistanceX = Math.Abs(distance.x);
            absDistanceZ = Math.Abs(distance.z);
            absDistanceY = Math.Abs(distance.y);

            if(absDistanceX > 0.1) distanceToObstacle.x = distance.x / absDistanceX;
            if(absDistanceZ > 0.1) distanceToObstacle.z = distance.z / absDistanceZ;
            if(absDistanceY > 0.1) distanceToObstacle.y = distance.y / absDistanceY;
            
            nextDestination = obstacle.transform.position + distanceToObstacle; 
        }

        return nextDestination;
    }
    
}
