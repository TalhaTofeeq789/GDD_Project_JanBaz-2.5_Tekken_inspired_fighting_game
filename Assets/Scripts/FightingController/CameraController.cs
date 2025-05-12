using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform[] targets;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void LateUpdate()
    {
        if (targets == null || targets.Length == 0)
        {
            return;
        }

        Transform activeTarget = FindActiveTarget();

        if (activeTarget == null)
        {
            return;
        }

        Vector3 desiredPosition = activeTarget.position + offset;
        desiredPosition.y = transform.position.y; 

        Vector3 smoothedPosition = Vector3.Lerp( transform.position,desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

    /*Transform FindActiveTarget()
    {
        foreach (Transform target in targets)
        {
            if(!target.gameObject.activeInHierarchy)
            {
                return target;
            }
            /*
            if (target != null && target.gameObject.activeInHierarchy)
            {
                return target;
            }//*
        }
        return null;
    }*/


    Transform FindActiveTarget()
    {
        foreach (Transform target in targets)
        {
            // Remove or comment out this incorrect condition:
            // if(!target.gameObject.activeInHierarchy)
            // {
            //     return target;
            // }

            // Uncomment and ensure this is the active condition:
            if (target != null && target.gameObject.activeInHierarchy)
            {
                return target;
            }
        }
        return null;
    }
}
