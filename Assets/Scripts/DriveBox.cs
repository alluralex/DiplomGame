using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms;

public class DriveBox : MonoBehaviour
{
    [SerializeField] private WheelCollider LeftBackWheel;
    [SerializeField] private WheelCollider RightBackWheel;
    [SerializeField] private WheelCollider RightFrontWheel;
    [SerializeField] private WheelCollider LeftFrontWheel;

    [SerializeField] private float _speedMove;
    [SerializeField] private float _speedRotate;
    [SerializeField] private Hero driver;
    [SerializeField] private Camera cameraCar;

    public Vector3 rawInputMovement;
    public Vector3 rawInputRotation;

    float HorizontalInput, VerticalInput;

    public void TryGoCar(Hero player)
    {
        if (driver == null)
        {
            driver = player;
            //player.gameObject.SetActive(false);
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

            //float GoCar = rawInputMovement.x * _speedMove;
            //float RotateCar = rawInputRotation.y * _speedRotate;

            //LeftBackWheel.motorTorque += GoCar;
            //RightBackWheel.motorTorque += GoCar;
            //RightFrontWheel.motorTorque += GoCar;
            //LeftFrontWheel.motorTorque += GoCar;

            //RightFrontWheel.steerAngle += RotateCar;
            //LeftFrontWheel.steerAngle += RotateCar;

        }
    }

    //public void OnRotateCar(InputAction.CallbackContext value)
    //{
    //    Vector2 vector2 = value.ReadValue<Vector2>();
    //    rawInputRotation = new Vector3(0, vector2.x, 0);
    //}

    //public void OnMoveCar(InputAction.CallbackContext value)
    //{
    //    Vector2 vector2 = value.ReadValue<Vector2>();
    //    rawInputMovement = new Vector3(vector2.x, 0, vector2.y);
    //}

}
