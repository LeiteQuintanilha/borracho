using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] ConstantForce torqueForce;
    [SerializeField] CharacterProperties properties;
    [SerializeField] Transform rayMove;
    [SerializeField] LayerMask mask = default;
    [SerializeField] Rigidbody rb;
    Vector3 infoPoint = Vector3.zero;



    void FixedUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        Physics.Raycast(rayMove.position, Vector3.down, out RaycastHit info, 100, mask.value);
        infoPoint = info.point;
        transform.Translate((new Vector3((info.point - transform.position).x,
                                     0,
                                     (info.point - transform.position).z)
                                     * properties.velocity
                                     * Time.deltaTime));

        torqueForce.force = new Vector3(horizontal * properties.forceFactor, 0, vertical * properties.forceFactor);


    }

    // void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.yellow;
    //     Gizmos.DrawCube(infoPoint, new Vector3(1, 1, 1));
    // }

}
