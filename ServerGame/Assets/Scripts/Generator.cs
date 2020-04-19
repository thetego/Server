using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
	public GameObject[] lights;
	public GameObject laptop;
	public Material emissiveLight;
	public bool working, issue;
	public float timer, limit;
	ServerHub sh;


    void Start()
    {
		sh = GameObject.Find("ServerHub").GetComponent<ServerHub>();
		limit = Random.Range(55, 155);
		Enable();
    }

    // Update is called once per frame
    void Update()
    {
		timer += Time.deltaTime;
		if (timer >= limit)
		{
			sh.generator = true;
			working = false;
			issue = true;
			sh.count = false;
			timer = 0;
		}
        if (working)
		{
			//Enable();
			laptop.SetActive(true);
		}
		else
		{
			for (int i = 0; i < lights.Length; i++)
			{
				lights[i].GetComponent<Light>().enabled = false;
			}
			laptop.SetActive(false);
		}
    }
	public void Enable()
	{
		lights[0].GetComponent<Light>().enabled = true;
		lights[1].GetComponent<Light>().enabled = true;
		lights[2].GetComponent<Light>().enabled = true;
		lights[3].GetComponent<Light>().enabled = true;
		lights[4].GetComponent<Light>().enabled = true;
		lights[5].GetComponent<Light>().enabled = true;
		lights[6].GetComponent<Light>().enabled = true;
		lights[7].GetComponent<Light>().enabled = true;
		lights[8].GetComponent<Light>().enabled = true;
	}
}
