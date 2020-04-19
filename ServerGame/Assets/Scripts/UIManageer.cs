using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManageer : MonoBehaviour
{
	public GameObject map, exp, desktop;
	public MouseLook ml;
	public FPSC fps;

	private void Awake()
	{
		map.SetActive(false);
	}


	private void LateUpdate()
	{
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			desktop.SetActive(false);
			map.SetActive(false);
			exp.SetActive(false);
			ml.enabled = true;
			fps.speed = 7;
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
	}
	public void EnableDesktop()
	{
		desktop.SetActive(true);
		ml.enabled = false;
		fps.speed = 0;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		fps.images[0].SetActive(false);
		fps.images[1].SetActive(false);
	}
	public void Map()
	{
		desktop.SetActive(false);
		map.SetActive(true);
	}
	public void Exp()
	{
		desktop.SetActive(false);
		exp.SetActive(true);
	}
}
