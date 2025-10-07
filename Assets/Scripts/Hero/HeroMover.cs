using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using System.Runtime.CompilerServices;

public class HeroMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 rawInputMovement;

    private void FixedUpdate()
    {
        if (rawInputMovement.x != 0 || rawInputMovement.z != 0)
        {

            transform.position += transform.TransformDirection(rawInputMovement) * _speed;
        }
    }

    public void OnMove(InputAction.CallbackContext value)
    {
        Vector2 vector2 = value.ReadValue<Vector2>();
        rawInputMovement = new Vector3(vector2.x, 0, vector2.y);
    }
}
