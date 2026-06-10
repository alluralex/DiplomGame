using System;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMove : MonoBehaviour
{
    public GameObject target;

    public bool IsNotMustRotate;
    public float speed = 0.5f;

    private Rigidbody rb;
    private Vector3 movement;
    private float rotationSpeed = 20f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        target = GameObject.Find("CarGood");
    }
    void Update()
    {
        Vector3 direction = target.transform.position - transform.position;
        direction.Normalize();
        movement = direction;
        if (Time.timeScale != 0)
        {
            speed = speed += 0.00005f;
        }
    }
    private void FixedUpdate()
    {
        MoveChar(movement);
        RotateChar(movement);
    }
    private void RotateChar(Vector3 directionToTarget)
    {
        if (IsNotMustRotate == false)
        {

            Vector3 direction = target.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
    private void MoveChar(Vector3 direction)
    {
        rb.MovePosition((Vector3)transform.position + (direction * speed * Time.deltaTime));
    }
}
