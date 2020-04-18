using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ServerHub : MonoBehaviour
{
	public GameObject[] servers;
	public GameObject sh;
	public MeshRenderer mr;
	public float timer;
	public Server server;
	public int index, mistake, point;
	public bool count;
	public Text pointtxt, mistaketxt;

	private void Awake()
	{
		for (int i = 0; i<sh.transform.childCount; i++)
		{
			servers[i] = sh.transform.GetChild(i).gameObject;
		}
		count = true;
	}
	private void Update()
	{
		pointtxt.text = "Score: " + point.ToString();
		mistaketxt.text = "Mistake: " + mistake.ToString();
		if (mistake >= 5)
		{
			SceneManager.LoadScene(0);
		}
		if (count)
		{
			timer += Time.deltaTime;
		}
		if (timer >= 3)
		{
			count = false;
			timer = 0;
			index = Random.Range(0, servers.Length);
			server = servers[index].GetComponent<Server>();
			server.issue = true;
			StartCoroutine(Wait());
		}
	}
	IEnumerator Wait()
	{
		yield return new WaitForSeconds(2.5f);
		server.issue = false;
		count = true;
		mistake++;
	}
}
