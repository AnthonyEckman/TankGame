using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Follow on target's X/Z plane
    //smooth rotations around target in 45 degree increments
    public Transform target;
    public Transform object1;
    public Transform object2;
    public Vector3 offsetPos;
    public float moveSpeed = 5;
    public float turnSpeed = 10;
    public float smoothSpeed = 0.5f;
    [Range(0,1)]
    public float zoomAmmount;

    Quaternion targetRotation;
    Vector3 targetPos;
    bool smoothRotating = false;

    private void Awake()
    {
        //StartCoroutine("RotateAroundTarget", -45);
    }
    private void Update()
    {
        target.position = CalculateMiddlePoint(object1,object2);
        KeepInFrame();


        MoveWithTarget();
        LookAtTarget();

        if(Input.GetKeyDown(KeyCode.G) && !smoothRotating)
        {
            StartCoroutine("RotateAroundTarget", 90);

        }
        if (Input.GetKeyDown(KeyCode.H) && !smoothRotating )
        {
            StartCoroutine("RotateAroundTarget", -90);
        }
        


    }

    public Vector3 CalculateMiddlePoint(Transform object1,Transform object2)
    {
        Vector3 middlePoint = object2.position + (object1.position - object2.position) / 2;

        return middlePoint;
    }

    public void KeepInFrame()
    {
        
            if (Vector3.Distance(target.position, object1.position) > Vector3.Distance(target.position, object2.position))
            {
                GetComponent<Camera>().orthographicSize = Vector3.Distance(target.position, object1.position) * zoomAmmount + 2;
            }
            else
            {
                GetComponent<Camera>().orthographicSize = Vector3.Distance(target.position, object2.position) * zoomAmmount + 2 ;
            }
        
        
    }

    //move the camera to the target position + current camera offset
    //offset is modified by the rotateAround coroutine
    private void MoveWithTarget()
    {
        targetPos = target.position + offsetPos;
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);

    }


    //use the look vector(target - current) to aim the camera toward the player
    private void LookAtTarget()
    {
        targetRotation = Quaternion.LookRotation(target.position - transform.position);
        
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        
        


    }

    // This coroutine can only have one instance running at a time
    // Determined by 'smoothRotation'
    IEnumerator RotateAroundTarget(float angle)
    {
        Vector3 vel = Vector3.zero;
        Vector3 targetOffsetPos = Quaternion.Euler(0, angle, 0) * offsetPos;
        float dist = Vector3.Distance(offsetPos, targetOffsetPos);
        smoothRotating = true;

        while(dist > 0.02f)
        {
            offsetPos = Vector3.SmoothDamp(offsetPos, targetOffsetPos, ref vel, smoothSpeed);
            dist = Vector3.Distance(offsetPos, targetOffsetPos);
            yield return null;
        }
        smoothRotating = false;
        offsetPos = targetOffsetPos;
    }




}
