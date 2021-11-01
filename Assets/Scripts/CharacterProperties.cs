using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character Property", menuName = "ScriptableObjects/CharacterProperty")]
public class CharacterProperties : ScriptableObject
{

    public float forceFactor = 10;
    public float velocity = 1;
    public Vector3 acelerationSensor = Vector3.zero;
    public float footVelocity = 1;
    public float aceleration = 0;
    public float stepLength = 2;
    public float stepHeight = 1;
    public float stepDistance = 1;
    [Space]
    public float SmoothTime = 0.3f;

    [SerializeField]
    private float twistVelocity;
    public float TwistVelocity
    {
        get { return twistVelocity; }
    }

    [SerializeField]
    private float distanceToTwist;
    public float DistanceToTwist
    {
        get { return distanceToTwist; }
    }
}
