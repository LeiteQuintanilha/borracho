using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    /*// camera will follow this object
    [SerializeField]
    private Transform Target;
    [SerializeField]
    private CharacterProperties properties;
    // offset between camera and target
    private Vector3 Offset;
    // change this value to get desired smoothness
    private float SmoothTime;

    // This value will change at the runtime depending on target movement. Initialize with zero vector.
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        Offset = transform.position - Target.position;
    }

    private void LateUpdate()
    {
        SmoothTime = properties.SmoothTime;
        // update position
        Vector3 targetPosition = Target.position + Offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime);

        //// update rotation
        //transform.LookAt(Target);
    }*/
    //A simple smooth follow camera,
    // that follows the targets forward direction
    [SerializeField]
    Transform target;
    float smooth = 0.3f;
    public Vector3 distance;
    float yVelocity = 0.0f;

    private void Start()
    {
        distance = new Vector3(0, 10, -50);
    }
    void Update()
    {
        // Damp angle from current y-angle towards target y-angle
        float yAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target.eulerAngles.y, ref yVelocity, smooth);
        // Position at the target
        Vector3 position = target.position;
        // Then offset by distance behind the new angle
        position += Quaternion.Euler(0, yAngle, 0) * distance;
        // Apply the position
        transform.position = position;

        // Look at the target
        transform.LookAt(target);
    }
}
