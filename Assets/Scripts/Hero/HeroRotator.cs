using Assets.Scripts.PlayerSettings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class HeroRotator : MonoBehaviour
{
    [SerializeField] public float _speed;

    private Vector3 rawInputRotation;

    private void Start()
    {
        Settings.Load();

        _speed = Settings.MouseGetting;
    }

    public void OnLook(InputAction.CallbackContext value)
    {
        Vector2 vector2 = value.ReadValue<Vector2>();
        rawInputRotation = new Vector3(0, vector2.x, 0);
    }

    private void Update()
    {
        transform.Rotate(rawInputRotation * _speed * 60 * Time.deltaTime);
    }

    public void CursosBlock()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
    }

    public void CursorUnblock()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
        UnityEngine.Cursor.visible = true;
    }
}
