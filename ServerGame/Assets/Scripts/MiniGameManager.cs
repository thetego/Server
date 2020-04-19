using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
	public GameObject Reflex,writing,matching;
	ServerHub sh;
	private void Awake()
	{
		sh = GameObject.Find("ServerHub").GetComponent<ServerHub>();
	}

	public void ReflexGame()
	{
		Reflex.SetActive(true);

	}
	public void WritingGame()
	{

		writing.SetActive(true);

	}
	public void MatchingGame()
	{

		matching.SetActive(true);
	}
}
