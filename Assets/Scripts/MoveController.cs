using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] ConstantForce force;
    [SerializeField] CharacterProperties properties;




    void FixedUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
           properties.velocity += 0.1f;
        }
        else 
        {
            properties.velocity = 0f;
        }

        force.force = new Vector3(horizontal * properties.forceFactor, 0, vertical * properties.forceFactor);
        transform.Translate(new Vector3(horizontal * properties.velocity * Time.deltaTime, 0, vertical * properties.velocity * Time.deltaTime));

    }



}
