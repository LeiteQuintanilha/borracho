using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{

    [SerializeField] private Transform leftRayposition;
    [SerializeField] private Transform rightRayposition;
    [SerializeField] private Transform leftTargetIK;
    [SerializeField] private Transform rightTargetIK;
    [SerializeField] private float speed;
    [SerializeField] private float stepDistance;
    [SerializeField] private float heightDistance;
    [SerializeField] LayerMask mask;

    private Vector3 leftFootNewPosition = default;
    private Vector3 rightFootNewPosition = default;
    private Vector3 leftFootOldPosition = default;
    private Vector3 rightFootOldPosition = default;
    private enum foot { right, left};
    foot actualFoot = foot.right;
    CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        leftFootOldPosition = leftRayposition.position;
        rightFootOldPosition = rightRayposition.position;


    }
    void FixedUpdate()
    {
        switch (actualFoot)
        {
            case foot.right:

                Ray rightRay = new Ray(rightRayposition.position, Vector3.down);

                if (Physics.Raycast(rightRay, out RaycastHit rightInfo, 10, mask.value))
                {
                    if (Vector3.Distance(rightInfo.point, rightFootOldPosition) > stepDistance)
                    {
                        rightFootNewPosition = rightInfo.point;
                    }
                    rightFootOldPosition = rightFootNewPosition;
                }
                break;
            case foot.left:
                Ray leftRay = new Ray(leftRayposition.position, Vector3.down);

                if (Physics.Raycast(leftRay, out RaycastHit leftInfo, 10, mask.value))
                {
                    if (Vector3.Distance(leftInfo.point, leftFootOldPosition) > stepDistance)
                    {
                        leftFootNewPosition = leftInfo.point;

                    }
                    leftFootOldPosition = leftFootNewPosition;

                }
                break;
        }

       

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(leftFootNewPosition, 0.5f);

        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(rightFootNewPosition, 0.5f);

    }


}
