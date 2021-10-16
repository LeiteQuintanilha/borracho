using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKFootSolver : MonoBehaviour
{
    [SerializeField] LayerMask terrainLayer = default;
    [SerializeField] Transform body = default;
    [SerializeField] IKFootSolver otherFoot = default;
    [SerializeField] CharacterProperties properties;
    [SerializeField] Color color;
    [SerializeField] Transform root;
    float speed = 1;
    float stepDistance = 4;
    float stepLength = 1;
    float stepHeight = 1;

    Vector3 oldPosition, currentPosition, newPosition;
    Vector3 oldNormal, currentNormal, newNormal;
    float lerp;

    private void Start()
    {
        currentPosition = newPosition = oldPosition = transform.position;
        currentNormal = newNormal = oldNormal = transform.up;
        lerp = 1;
    }


    void FixedUpdate()
    {
        transform.position = currentPosition;
        transform.up = currentNormal;
        speed = properties.footVelocity;
        stepDistance = properties.stepDistance;
        stepHeight = properties.stepHeight;
        stepLength = properties.stepLength;
        transform.rotation = root.rotation;
        Ray ray = new Ray(body.position, Vector3.down);

        if (Physics.Raycast(ray, out RaycastHit info, 100, terrainLayer.value))
        {
            if (Vector3.Distance(newPosition, info.point) > stepDistance && !otherFoot.IsMoving() && lerp >= 1)
            {
                Vector3 directionStep = (info.point - currentPosition).normalized;
                lerp = 0;
                // int direction = body.InverseTransformPoint(info.point).z > body.InverseTransformPoint(newPosition).z ? 1 : -1;
                newPosition = info.point + (directionStep * stepLength);
                newNormal = info.normal;
            }
        }

        if (lerp < 1)
        {
            Vector3 tempPosition = Vector3.Lerp(oldPosition, newPosition, lerp);
            tempPosition.y += Mathf.Sin(lerp * Mathf.PI) * stepHeight;

            currentPosition = tempPosition;
            currentNormal = Vector3.Lerp(oldNormal, newNormal, lerp);
            lerp += Time.deltaTime * speed;
        }
        else
        {
            oldPosition = newPosition;
            oldNormal = newNormal;
        }
    }

    /*void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(newPosition, 1f);
    }*/



    public bool IsMoving()
    {
        return lerp < 1;
    }



}

