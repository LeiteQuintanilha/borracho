using System.Collections;
using System.Collections.Generic;
using DitzelGames.FastIK;
using UnityEngine;

public class JointsBreakeNotify : MonoBehaviour
{
    [SerializeField] FastIKFabric leftIkFabric;
    [SerializeField] FastIKFabric rightIkFabric;
    private void OnJointBreak(float breakForce)
    {
        leftIkFabric.enabled = false;
        rightIkFabric.enabled = false;
    }
}