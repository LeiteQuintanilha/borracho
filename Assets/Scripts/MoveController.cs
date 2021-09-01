using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{

    [SerializeField] private Transform Rayposition;
    [SerializeField]private Transform baseObject;
    [SerializeField] private float speed;
    [SerializeField] private float stepDistance;
    [SerializeField] private float giro;
    CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();

    }
    void FixedUpdate()
    {
        float rotationX = Input.GetAxis("Horizontal") * giro;
        float rotationY = Input.GetAxis("Vertical") * giro;
        baseObject.transform.eulerAngles = new Vector3(rotationX, 0, rotationY);
        Debug.Log($"{baseObject.transform.rotation}");


        if (Physics.Raycast(Rayposition.position, transform.TransformDirection(Vector3.down), out RaycastHit hit))
        {
            if (Vector3.Distance(transform.position, hit.point) > stepDistance)
            {
                Debug.Log($"{Vector3.Distance(transform.position, hit.point)}");

                Vector3 direction = (transform.position - hit.point).normalized;
                direction.y = 0.5f;
                controller.Move(direction * Time.deltaTime * -speed);

            }
        }
    }
}
