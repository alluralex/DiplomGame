using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{

    [Header("Sub Behaviours")]
    public HeroMover playerMovementBehaviour;


    [Header("Input Settings")]
    public PlayerInput playerInput;
    public float movementSmoothingSpeed = 1f;
    private Vector3 rawInputMovement;
    private Vector3 smoothInputMovement;
    
    //Action Maps
    private string actionMapPlayerControls = "Player Controls";
    private string actionMapMenuControls = "Menu Controls";

    private string currentControlScheme;



    public void OnMove(InputAction.CallbackContext value)
    {
        Vector2 inputMovement = value.ReadValue<Vector2>();
        rawInputMovement = new Vector3(inputMovement.x, 0, inputMovement.y);
    }

    void Update()
    {
        CalculateMovementInputSmoothing();
        UpdatePlayerMovement();
    }
    void CalculateMovementInputSmoothing()
    {
        
        smoothInputMovement = Vector3.Lerp(smoothInputMovement, rawInputMovement, Time.deltaTime * movementSmoothingSpeed);

    }
    void UpdatePlayerMovement()
    {
        playerMovementBehaviour.UpdateMovementData(smoothInputMovement);
    }

    public PlayerInput GetPlayerInput()
    {
        return playerInput;
    }


}
