using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RexlexGame : MonoBehaviour
{

	public Image field, indicator, pressField;
	public bool rotate, pressed;
	public Transform[] pos;
	int posIndex;
	float speed = 75f;
	ServerHub sh;
	public MouseLook ml;
	public FPSC fps;
	public Generator gen;

    void Start()
    {
		ml.enabled = false;
		fps.speed = 0;
		sh = GameObject.Find("ServerHub").GetComponent<ServerHub>();
		rotate = true;
		pressed = false;
		posIndex = 0;
    }

    void Update()
    {
		switch (sh.level)
		{
			case 1:
				speed = 70f;
				break;
			case 2:
				speed = 65;
				break;
			case 3:
				speed = 60;
				break;
			case 4:
				speed = 55;
				break;
			case 5:
				speed = 50;
				break;
		}
		ml.enabled = false;
		fps.speed = 0;
		if (Vector3.Distance(pos[posIndex].position, indicator.transform.position) < .2f)
		{
			posIndex++;
			if (posIndex >= pos.Length)
			{
				posIndex = 0;
			}
		}
		indicator.transform.position = Vector3.MoveTowards(indicator.transform.position, pos[posIndex].position,speed*Time.deltaTime);
		//print(Vector3.Distance(pressField.transform.position, indicator.transform.position));
		if (Vector3.Distance(pressField.transform.position, indicator.transform.position) <= 3.5f && Input.GetMouseButtonDown(0))
		{
			if (sh.generator)
			{
				ml.enabled = true;
				fps.speed = 7;
				sh.server.burn = false;
				sh.server.burned = false;
				sh.count = false;
				sh.server.issue = false;
				sh.generator = false;
				gen.Enable();
				gen.working = true;
				this.gameObject.SetActive(false);
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

		}
		if (Vector3.Distance(pressField.transform.position, indicator.transform.position) >= 3.5f && Input.GetMouseButtonDown(0))
		{
			print("missed");
		}

	}
}
