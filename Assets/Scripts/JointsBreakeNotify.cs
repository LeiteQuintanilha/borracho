using System.Collections;
using System.Collections.Generic;
using DitzelGames.FastIK;
using UnityEngine;

public class JointsBreakeNotify : MonoBehaviour
{
    [SerializeField] FastIKFabric leftIkFabric;
    [SerializeField] FastIKFabric rightIkFabric;
    [SerializeField] MovementController movementController;

    private void OnJointBreak(float breakForce)
    {
        movementController.enabled = false;
        leftIkFabric.enabled = false;
        rightIkFabric.enabled = false;
    }



}