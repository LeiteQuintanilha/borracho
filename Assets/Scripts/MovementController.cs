using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] CharacterProperties properties;
    [SerializeField] ConstantForce constForce;
    float distanceToTwist;
    float twistVelocity;
    private Quaternion oldRotation;
    private Quaternion newRotation;
    private float lerp;
    private Quaternion currentRotation;
    private Vector3 aceleration;
    private float acelerationMagnitude;

    void Start()
    {
        lerp = 1;
        currentRotation = newRotation = oldRotation = transform.rotation;
    }


    void FixedUpdate()
    {
        //var horizontal = Input.GetAxis("Horizontal");
        //var vertical = Input.GetAxis("Vertical");
        aceleration = properties.acelerationSensor;
        acelerationMagnitude = aceleration.magnitude;
        twistVelocity = properties.TwistVelocity;
        distanceToTwist = properties.DistanceToTwist;
        transform.rotation = currentRotation;

        constForce.force = aceleration * properties.forceFactor;
        transform.Translate(aceleration * Time.deltaTime * properties.velocity, Space.World);

        if (lerp >= 1 && aceleration.magnitude > distanceToTwist)
        {
            oldRotation = newRotation;
            Vector3 direction = aceleration;
            direction.y = 0;
            newRotation = Quaternion.LookRotation(direction);

            //Vector3 actual = transform.rotation.eulerAngles;
            Vector3 futura = newRotation.eulerAngles;
            futura.x = 0;
            futura.z = 0;
            lerp = 0;
        }
        else if (lerp < 1)
        {
            Quaternion tempRotation = Quaternion.Slerp(oldRotation, newRotation, lerp);
            currentRotation = tempRotation;
            lerp += Time.deltaTime * twistVelocity;
        }
        else
        {
            oldRotation = newRotation;
        }

    }
}
