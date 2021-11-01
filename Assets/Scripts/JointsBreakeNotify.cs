using System.Collections;
using System.Collections.Generic;
using DitzelGames.FastIK;
using UnityEngine;

public class JointsBreakeNotify : MonoBehaviour
{
    [SerializeField] FastIKFabric leftIkFabric;
    [SerializeField] FastIKFabric rightIkFabric;
    [SerializeField] MovementController movementController;
    [SerializeField] RestartGame restartGame;

    private void OnJointBreak(float breakForce)
    {
        movementController.enabled = false;
        leftIkFabric.enabled = false;
        rightIkFabric.enabled = false;
        Invoke("Restart", 5);
    }

    void Restart()
    {
        Debug.Log("restart");

        restartGame.RestartGameSwitch();
    }


}