using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Server : MonoBehaviour
{
	public bool issue;

	private void Update()
	{
		if (issue)
		{
			GetComponent<MeshRenderer>().material.color = Color.red;
		}
		else
		{
			GetComponent<MeshRenderer>().material.color = Color.white;
		}
	}

}
