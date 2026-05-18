using Assets.Scripts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms;

public class DriveBox : MonoBehaviour, ITakeDamage
{
    [SerializeField] private WheelCollider LeftBackWheel;
    [SerializeField] private WheelCollider RightBackWheel;
    [SerializeField] private WheelCollider RightFrontWheel;
    [SerializeField] private WheelCollider LeftFrontWheel;

    [SerializeField] public Transform seatPoint;

    [SerializeField] public float _speedMove;
    [SerializeField] public float _speedRotate;
    [SerializeField] private Hero driver;
    [SerializeField] private Camera cameraCar;

    public event Action<int> OnHealthCnanged;

    public int CurrentHealth;


    public Vector3 rawInputMovement;
    public Vector3 rawInputRotation;

    float HorizontalInput, VerticalInput;

    public bool IsAlive => throw new NotImplementedException();

    public void TryGoCar(Hero player)
    {
        if (driver == null)
        {
            driver = player;
        }
        else
        {
            Debug.Log("Тачка забита до отказа...");
        }
    }

    private void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        if (driver != null)
        {
            float motor = Input.GetAxis("Vertical") * _speedMove;
            LeftBackWheel.motorTorque = motor;
            RightBackWheel.motorTorque = motor;
            RightFrontWheel.motorTorque = motor;
            LeftFrontWheel.motorTorque = motor;

            RightFrontWheel.steerAngle = _speedRotate * HorizontalInput;
            LeftFrontWheel.steerAngle = _speedRotate * HorizontalInput;
        }
        else
        {

            LeftBackWheel.motorTorque = 0;
            RightBackWheel.motorTorque = 0;
            RightFrontWheel.motorTorque = 0;
            LeftFrontWheel.motorTorque = 0;
        }
    }
    public void RemoveDriver()
    {
        driver = null;

        if (cameraCar != null)
            cameraCar.enabled = false;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        OnHealthCnanged.Invoke(CurrentHealth);
        if (CurrentHealth <= 0)
        {
            Destroy(this);
            GlobalEvents.CarCrashed?.Invoke();
        }
    }

    internal void AddHealth(int amountHealth)
    {
        CurrentHealth += amountHealth;
        OnHealthCnanged?.Invoke(CurrentHealth);
    }
}
