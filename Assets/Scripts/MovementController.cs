using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] ConstantForce torqueForce;
    [SerializeField] CharacterProperties properties;
    [SerializeField] Transform rayMove;
    [SerializeField] LayerMask mask = default;
    [SerializeField] Rigidbody rb;
    [SerializeField] AcelerationController aceleration;
    float distanceToTwist;
    float twistVelocity;
    Vector3 infoPoint;
    private Quaternion oldRotation;
    private Quaternion newRotation;
    private float lerp;
    private Quaternion currentRotation;

    void Start()
    {
        lerp = 1;
        currentRotation=newRotation = oldRotation = transform.rotation;
    }


    void FixedUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        twistVelocity = properties.TwistVelocity;
        distanceToTwist = properties.DistanceToTwist;
        transform.rotation = currentRotation;
        transform.Translate(aceleration.Aceleration * Time.deltaTime * properties.velocity, Space.World);

        //torqueForce.force = new Vector3(aceleration.Aceleration.x * properties.forceFactor,
        //                                0,
        //                                aceleration.Aceleration.z * properties.forceFactor);

        
        if (lerp >= 1 && aceleration.Aceleration.magnitude > distanceToTwist)
        {
            oldRotation = newRotation;

            Vector3 direction = aceleration.Aceleration;
            direction.y = 0;
            //newRotation.SetFromToRotation(transform.forward, (direction *10).normalized);
            newRotation = Quaternion.LookRotation(direction);

            Vector3 actual = transform.rotation.eulerAngles;
            Vector3 futura = newRotation.eulerAngles;
            Debug.Log($"direction{direction}/actual{actual}/future{futura}");

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
