using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private bool rotateToFace;

    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        transform.LookAt(target);
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (rotateToFace)
            transform.LookAt(target);
        else
            transform.position = target.position + offset;
    }
}
