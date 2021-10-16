using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcelerationController : MonoBehaviour
{

    [SerializeField]
    private Vector3 aceleration;

    public Vector3 Aceleration
    {
        get { return aceleration; }
        set { aceleration = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        aceleration = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        aceleration.x = Input.acceleration.x;
        aceleration.z = Input.acceleration.y;
    }
}
