using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Writing : MonoBehaviour
{
	public string[] words = System.IO.File.ReadAllLines("Assets/Scripts/Words.txt");
	public Text currentWord;
	public InputField _inputField;
	public Text[] history;
	public float timer;
	public int index, hindex = 0;
	public MouseLook ml;
	public FPSC fps;
	int point;
	public ServerHub sh;
	public Generator gen;

	private void Start()
	{
		ml.enabled = false;
		fps.speed = 0;
		hindex = 0;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
	private void Update()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		ml.enabled = false;
		fps.speed = 0;
		timer += Time.deltaTime;
		if (timer >= 5f)
		{
			index = Random.Range(0, words.Length);
			currentWord.text = words[index];
			timer = 0;
		}
		if (hindex >= 3)
		{
			hindex = 0;
		}
		if (_inputField.text == currentWord.text && Input.GetKeyDown(KeyCode.Return))
		{
			point++;
			if (hindex != 0)
			{
				history[hindex].text = history[hindex - 1].text;
			}
			history[hindex].text = words[index];
			_inputField.text = " ";
			timer = 5f;
			hindex++;
		}
		if (point >= 10-sh.level)
		{
			if (sh.generator)
			{
				ml.enabled = true;
				fps.speed = 7;
				sh.server.burn = false;
				sh.server.burned = false;
				sh.count = false;
				sh._fade = true;
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
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			point = 0;
			history[0].text = "";
			history[1].text = "";
			history[2].text = "";
		}
	}
}
