using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class HeroRotator : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 rawInputRotation;

    private void Start()
    {
        CursosBlock();
    }

    public void OnLook(InputAction.CallbackContext value)
    {
        Vector2 vector2 = value.ReadValue<Vector2>();
        rawInputRotation = new Vector3(0, vector2.x, 0);
    }

    private void Update()
    {
        transform.Rotate(rawInputRotation * _speed * Time.deltaTime);
    }

    void CursosBlock()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
    }
}
