using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

	[SerializeField]
	[Range(0, 250f)]
	float sensivity;

	public Transform _body;

	float xRot;

    void Start()
    {
		Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
		float MouseX = Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
		float MouseY = Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;

		xRot -= MouseY;
		xRot = Mathf.Clamp(xRot, -90f, 90f);

		transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
		_body.Rotate(Vector3.up * MouseX);
    }
}
