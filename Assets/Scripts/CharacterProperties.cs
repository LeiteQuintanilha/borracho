using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character Property", menuName = "ScriptableObjects/CharacterProperty")]
public class CharacterProperties : ScriptableObject
{

    public ConstantForce force;
    public float forceFactor = 10;
    public float velocity = 1;
    public float aceleration = 0;
}
