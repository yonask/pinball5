﻿using UnityEngine;
using System.Collections;
using Windows.Kinect;
using System.Collections;

public class DetectJoints : MonoBehaviour
{
    public GameObject BodySrcManager;
    public JointType TrackedJoint;
    private BodySourceManager bodyManager;
    private Body[] bodies;
    public float multiplier;
    public float xMin, xMax, zMin, zMax;
    // Use this for initialization
    void Start()
    {

        if (BodySrcManager == null)
        {
            Debug.Log("Assign Game Object with Body source Manager");
        }
        else
        {
            bodyManager = BodySrcManager.GetComponent<BodySourceManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (bodyManager == null)
        {
            return;
        }

        bodies = bodyManager.GetData();

        if (bodies == null)
        {
            return;
        }
        foreach (var body in bodies)
        {
            if (body == null)
            {
                continue;
            }
            if (body.IsTracked)
            {
                var pos = body.Joints[TrackedJoint].Position;
                gameObject.transform.position = new Vector3(Mathf.Clamp(pos.X * multiplier, xMin, xMax), 0.0f, Mathf.Clamp(pos.Z * multiplier - 20, zMin, zMax));
            }
        }



    }
}