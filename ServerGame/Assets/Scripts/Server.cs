using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Server : MonoBehaviour
{
	public bool issue, burn, burned;
	public GameObject _burned;
	public ParticleSystem[] _ps;


	private void Start()
	{
		_ps[0].enableEmission = false;
		_ps[1].enableEmission = false;
	}

	private void Update()
	{
		if (burn)
		{
			_ps[0].enableEmission = true;
			_ps[1].enableEmission = true;
		}
		else
		{
			_ps[0].enableEmission = false;
			_ps[1].enableEmission = false;
		}
		if (burned)
		{
			_burned.SetActive(true);
			gameObject.SetActive(false);
		}
	}

}
