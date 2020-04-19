using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ServerHub : MonoBehaviour
{
	public GameObject[] servers;
	public Image[] TroubleIndacators;
	public GameObject Troubles;
	public GameObject sh;
	public MeshRenderer mr;
	public float timer;
	public Server server;
	public int index, mistake;
	public bool count, generator, _fade;
	public Text pointtxt, leveltxt;
	public int level;
	public float fade, point;

	private void Awake()
	{
		for (int i = 0; i<sh.transform.childCount; i++)
		{
			servers[i] = sh.transform.GetChild(i).gameObject;
		}
		for (int i = 0; i < Troubles.transform.childCount; i++)
		{
			TroubleIndacators[i] = Troubles.transform.GetChild(i).GetComponent<Image>();
			TroubleIndacators[i].gameObject.SetActive(false);
		}
		count = true;
	}
	private void Update()
	{
		if (_fade)
		{
			fade += 0.2f * Time.deltaTime;
			pointtxt.color = new Color(255, 255, 255, fade);
			point += 30 * Time.deltaTime;
			if (point >= 50)
			{
				point = 50;
				fade -= 1 * Time.deltaTime;
				if (fade <= 0)
				{
					fade = 0;
				}
			}
		}
		/*if (point >= 5)
		{
			level = level + 1;
			//point = 0;
		}*/
		leveltxt.text = "Leve: " + level.ToString();
		pointtxt.text = "POINT \n" + Mathf.RoundToInt(point).ToString();
		if (mistake >= 5)
		{
			SceneManager.LoadScene(0);
		}
		if (count)
		{
			timer += Time.deltaTime;
		}
		if (timer >= 5)
		{
			_fade = false;
			count = false;
			generator = false;
			timer = 0;
			index = Random.Range(0, servers.Length);
			server = servers[index].GetComponent<Server>();
			if (server.burned)
			{
				count = true;
				return;
			}
			TroubleIndacators[index].gameObject.SetActive(true);
			server.issue = true;
			StartCoroutine(Wait());
		}
	}
	IEnumerator Wait()
	{
		yield return new WaitForSeconds(10f);
		server.burn = true;
		yield return new WaitForSeconds(8f);

		server.burned = true;
		count = true;
		mistake++;
	}

}
