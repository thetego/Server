using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerHub : MonoBehaviour
{
	public GameObject[] servers;
	public GameObject sh;
	public MeshRenderer mr;
	public float timer;
	public Server server;
	public int index;
	public bool count;

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

		IEnumerator Wait()
		{
			yield return new WaitForSeconds(2.5f);
			server.issue = false;
			count = true;
		}
	}
}
