using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class CharacterMoveManager : MonoBehaviour
{

    private float range = 6f;

    public Transform startposition;

    // Movement speed in units per second.
    public float speed = 1f;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    Vector3 up;
    Vector3 down;
    Vector3 right;
    Vector3 left;
    Vector3 nextPosition;

    private void Awake()
    {
        OrganizeDirection();
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

    private void Move(SwipeData data)
    {

        Debug.Log(ScoreManager.femaleOntheButton);

        startTime = Time.time;
        startposition = transform;

        switch (data.Direction)
        {            
            case SwipeDirection.Up:
                nextPosition = DetectNextPosition(up);     
                break;
            case SwipeDirection.Down:
                nextPosition = DetectNextPosition(down);
                break;
            case SwipeDirection.Left:
                nextPosition = DetectNextPosition(left);
                break;
            case SwipeDirection.Right:
                nextPosition = DetectNextPosition(right);
                break;
        }
        journeyLength = Vector3.Distance(transform.position, nextPosition);
    }

    private Vector3 DetectNextPosition(Vector3 moveDirection)
    {
        RaycastHit obstacle;
        Vector3 nextDestination = new Vector3();

        int obstacLesLayer = 1 << 8;
        int borderLayer = 1 << 10;

        if (this.tag.Equals("Male")) { obstacLesLayer = 1 << 8; }
        else if (this.tag.Equals("Female")) { obstacLesLayer = 1 << 9; }

        if (Physics.Raycast(transform.position, transform.TransformDirection(moveDirection),out obstacle, range, obstacLesLayer))
        {
            Vector3 distanceToObstacle = new Vector3(0,0,0);
            Vector3 distance;

            float absDistanceX;
            float absDistanceZ;
            float absDistanceY;
            
            distance = transform.position - obstacle.transform.position;
      
            absDistanceX = Math.Abs(distance.x);
            absDistanceZ = Math.Abs(distance.z);
            absDistanceY = Math.Abs(distance.y);

            if(absDistanceX > 0.1) distanceToObstacle.x = distance.x / absDistanceX;
            if(absDistanceZ > 0.1) distanceToObstacle.z = distance.z / absDistanceZ;
            if(absDistanceY > 0.1) distanceToObstacle.y = distance.y / absDistanceY;
            
            nextDestination = obstacle.transform.position + distanceToObstacle;
        }
        else if(Physics.Raycast(transform.position, transform.TransformDirection(moveDirection), out obstacle, range, borderLayer))
        {
            nextDestination = DetectFallingPosition(moveDirection, obstacle);
            Debug.Log(obstacle.transform.position);
        }

        return nextDestination;
    }

    private Vector3 DetectFallingPosition(Vector3 moveDirect, RaycastHit obs)
    {
        Vector3 temp;
        temp = transform.position;

        if (moveDirect == up || moveDirect == down) {
            temp.x = obs.transform.position.x;
        }else if( moveDirect == right || moveDirect == left)
        {
            temp.z = obs.transform.position.z;
        }
        return temp;      
    }


    private void OrganizeDirection()
    {
        switch (this.tag)
        {
            case "Male":
                up = transform.TransformDirection(Vector3.right);
                down = transform.TransformDirection(Vector3.left);
                left = transform.TransformDirection(Vector3.back);
                right = transform.TransformDirection(Vector3.forward);
                break;
            case "Female":
                up = transform.TransformDirection(Vector3.left);
                down = transform.TransformDirection(Vector3.right);
                left = transform.TransformDirection(Vector3.back);
                right = transform.TransformDirection(Vector3.forward);
                break;
        }      
    }
}
