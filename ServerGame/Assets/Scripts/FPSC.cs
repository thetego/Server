using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSC : MonoBehaviour
{
	[Range(0,24)]
	public float speed;
	CharacterController cc;
	ServerHub sh;

	private void Awake()
	{
		cc = GetComponent<CharacterController>();
		sh = GameObject.Find("ServerHub").GetComponent<ServerHub>();
	}

	private void Update()
	{
		float h = Input.GetAxis("Horizontal");
		float v= Input.GetAxis("Vertical");

		Vector3 move = transform.right * h + transform.forward * v;

		cc.Move(move * speed * Time.deltaTime);

		RaycastHit hit;
		if (Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out hit,Mathf.Infinity))
		{
			if (Input.GetMouseButtonDown(0)&&hit.transform.tag=="Server"&&hit.transform.GetComponent<Server>().issue)
			{
				print("matched");
				sh.StopAllCoroutines();
				sh.server.issue = false;
				sh.count = true;
			}
		}
	}
}
