using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
	[SerializeField]
	private Camera _mainCamera;

	private void Start()
	{
		_mainCamera = Camera.main;
	}

	private void LateUpdate()
	{
		Vector3 cameraPosition = _mainCamera.transform.position;

		cameraPosition.y = transform.position.y;

		transform.LookAt(cameraPosition);
		transform.Rotate(0f, 180f, 0f);
	}
}
