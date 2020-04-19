using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Matches : MonoBehaviour
{
	public Button[] first;
	public Button[] second;
	public Image[] connections;
	bool pressed;
	public bool[] colors, colors1;
	public MouseLook ml;
	public FPSC fps;
	public ServerHub sh;
	public Generator gen;

	private void Start()
	{
		for (int i =0; i < connections.Length; i++)
		{
			connections[i].gameObject.SetActive(false);
		}
	}

	private void Update()
	{
		ml.enabled = false;
		fps.speed = 0;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		if (colors[0]&&colors[1]&&colors[2]&&colors[3]&&colors[4]&& colors1[0] && colors1[1] && colors1[2] && colors1[3] && colors1[4])
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			if (sh.generator)
			{
				ml.enabled = true;
				fps.speed = 7;
				sh.server.burn = false;
				sh.server.burned = false;
				sh.count = false;
				sh.server.issue = false;
				gen.working = true;
				gen.Enable();
				this.gameObject.SetActive(false);
				sh.generator = false;
			}
			if (!sh.generator)
			{
				sh.point = 0;
				sh.server.issue = false;
				sh.count = true;
				sh._fade = true;
				sh.TroubleIndacators[sh.index].gameObject.SetActive(false);
				ml.enabled = true;
				fps.speed = 7;
				sh.server.burn = false;
				sh.server.burned = false;
				this.gameObject.SetActive(false);
			}
			Reset();
		}
	}

	public void Blue()
	{
		colors[0] = true;
	}
	public void Red()
	{
		colors[1] = true;

	}
	public void Green()
	{
		colors[2] = true;

	}
	public void Yellow()
	{
		colors[3] = true;

	}
	public void Orange()
	{
		colors[4] = true;

	}
	public void Blue2()
	{
		if (colors[0])
		{
			colors1[0]=true;
			connections[0].gameObject.SetActive(true);
		}
	}
	public void Red2()
	{
		if (colors[1])
		{
			colors1[1] = true;
			connections[1].gameObject.SetActive(true);
		}

	}
	public void Green2()
	{
		if (colors[2])
		{
			colors1[2] = true;
			connections[2].gameObject.SetActive(true);
		}
	}
	public void Yellow2()
	{
		if (colors[3])
		{
			colors1[3] = true;
			connections[3].gameObject.SetActive(true);
		}
	}
	public void Orange2()
	{
		if (colors[4])
		{
			colors1[4] = true;
			connections[4].gameObject.SetActive(true);
		}
	}
	private void Reset()
	{
		colors[0] = false;
		colors[1] = false;
		colors[2] = false;
		colors[3] = false;
		colors[4] = false;
		colors1[0] = false;
		colors1[1] = false;
		colors1[2] = false;
		colors1[3] = false;
		colors1[4] = false;
		connections[0].gameObject.SetActive(false);
		connections[1].gameObject.SetActive(false);
		connections[2].gameObject.SetActive(false);
		connections[3].gameObject.SetActive(false);
		connections[4].gameObject.SetActive(false);
	}
}
