using Assets.Scripts.Inventory.Upgrade;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeroMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 rawInputMovement;

    [SerializeField] private UpgradeInfo Stats;

    [SerializeField] private Animator animator;
    private void FixedUpdate()
    {
        if (rawInputMovement.x != 0 || rawInputMovement.z != 0)
        {
            transform.position += transform.TransformDirection(rawInputMovement) * _speed * Stats.speedMultiplayer;
        }
        animator.SetFloat("MoveX", rawInputMovement.x);
        animator.SetFloat("MoveY", rawInputMovement.z);
    }

    public void OnMove(InputAction.CallbackContext value)
    {
        Vector2 vector2 = value.ReadValue<Vector2>();
        rawInputMovement = new Vector3(vector2.x, 0, vector2.y);
    }

}
