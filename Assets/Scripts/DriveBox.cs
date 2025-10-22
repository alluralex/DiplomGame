using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DriveBox : MonoBehaviour
{
    [SerializeField] private float _speedMove;
    [SerializeField] private float _speedRotate;
    [SerializeField] Hero driver;
    [SerializeField] List<Hero> passengers;

    [SerializeField] private Rigidbody bodyOfCar;

    public Vector3 rawInputMovement;
    public Vector3 rawInputRotation;


    public void TryGoCar(Hero player)
    {
        if (driver == null)
        {
            driver = player;
            //player.gameObject.SetActive(false);
        }
        else if (driver != null && passengers.Count <= 3)
        {
            passengers.Add(player);
            //player.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Тачка забита до отказа...");
        }
    }

    private void FixedUpdate()
    {
        if (driver != null)
        {
            //if (rawInputRotation.y != 0)
            //{
            //}
            //if (rawInputMovement.x != 0 || rawInputMovement.z != 0)
            //{
            //}
                bodyOfCar.AddTorque(rawInputRotation * _speedRotate * Time.deltaTime);
                bodyOfCar.AddForce(rawInputMovement * _speedMove * Time.deltaTime);
        }
    }

    public void OnRotateCar(InputAction.CallbackContext value)
    {
        Vector2 vector2 = value.ReadValue<Vector2>();
        rawInputRotation = new Vector3(0, vector2.x, 0);
    }

    public void OnMoveCar(InputAction.CallbackContext value)
    {
        Vector2 vector2 = value.ReadValue<Vector2>();
        rawInputMovement = new Vector3(vector2.x, 0, vector2.y);
    }

}
