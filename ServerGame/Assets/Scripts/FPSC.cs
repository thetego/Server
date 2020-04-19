using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSC : MonoBehaviour
{
	[Range(0,24)]
	public float speed;
	CharacterController cc;
	ServerHub sh;
	UIManageer uim;
	MiniGameManager mgm;
	int index;
	public float gravity;
	Vector3 velocity;
	public GameObject fireext, wallfireext;
	public ParticleSystem fireectpar;
	public Generator generator;
	public GameObject[] images;

	private void Awake()
	{
		cc = GetComponent<CharacterController>();
		sh = GameObject.Find("ServerHub").GetComponent<ServerHub>();
		uim = GameObject.Find("GameManager").GetComponent<UIManageer>();
		mgm = GameObject.Find("GameManager").GetComponent<MiniGameManager>();
		fireext.SetActive(false);
		wallfireext.SetActive(true);
		fireectpar.enableEmission = false;
	}

	private void Update()
	{
		float h = Input.GetAxis("Horizontal");
		float v= Input.GetAxis("Vertical");

		Vector3 move = transform.right * h + transform.forward * v;

		cc.Move(move * speed * Time.deltaTime);

		velocity.y += -gravity * Time.deltaTime;

		cc.Move(velocity * Time.deltaTime);

		RaycastHit hit;
		if (Physics.Raycast(Camera.main.transform.position,Camera.main.transform.TransformDirection(Vector3.forward),out hit,2.5f))
		{
			if (hit.transform.tag == "Server" || hit.transform.tag == "Fire" || hit.transform.tag == "Generator") 
			{ 
				images[0].SetActive(true);	
				images[1].SetActive(false); 
			}
			else if (hit.transform.tag == "Desk") 
			{ 
				images[0].SetActive(false);	
				images[1].SetActive(true); 
			}
			if (Input.GetMouseButtonDown(0)&&hit.transform.tag=="Server"&&hit.transform.GetComponent<Server>().issue&&!hit.transform.GetComponent<Server>().burn && !hit.transform.GetComponent<Server>().burned)
			{
				sh.StopAllCoroutines();
				index = Random.Range(1, 4);
				if (index == 1)
				{
					mgm.ReflexGame();
				}
				if (index == 2)
				{
					mgm.WritingGame();
				}
				if (index == 3)
				{
					mgm.MatchingGame();
				}
				sh.server.issue = false;
			}
			if (Input.GetKeyDown(KeyCode.E) && hit.transform.tag == "Desk")
			{
				print("asdkla");
				uim.EnableDesktop();
			}

			if (Input.GetMouseButtonDown(0) && hit.transform.tag == "Fire")
			{
				wallfireext.SetActive(false);
				fireext.SetActive(true);
			}

			if (Input.GetMouseButtonDown(0) && hit.transform.tag == "Generator"&& !generator.working&& sh.generator&&generator.issue)
			{
				sh.StopAllCoroutines();
				index = Random.Range(1, 4);
				if (index == 1)
				{
					mgm.ReflexGame();
				}
				if (index == 2)
				{
					mgm.WritingGame();
				}
				if (index == 3)
				{
					mgm.MatchingGame();
				}
				sh.server.issue = false;
				generator.issue = false;
			}

			if (fireext.activeSelf==true&&sh.server.issue && hit.transform.GetComponent<Server>().burn && !hit.transform.GetComponent<Server>().burned && Input.GetMouseButtonDown(0) && hit.transform.tag == "Server")
			{
				fireectpar.gameObject.SetActive(true);
				StartCoroutine(Fire());
			}
			if (fireext.activeSelf == true)
			{
				if (Input.GetKeyDown(KeyCode.E))
				{
					fireext.SetActive(false);
					wallfireext.SetActive(true);
				}
			}
		}
		else
		{
			images[0].SetActive(false);
			images[1].SetActive(false);
		}
		Vector3 forward = Camera.main.transform.TransformDirection(Vector3.forward) * 2.5f;
		Debug.DrawRay(Camera.main.transform.position, forward, Color.green);
	}
	IEnumerator Fire()
	{
		fireectpar.enableEmission = true;
		yield return new WaitForSeconds(3f);
		fireectpar.enableEmission = false;
		fireectpar.gameObject.SetActive(false);
		sh.TroubleIndacators[sh.index].gameObject.SetActive(false);
		sh.server.burn = false;
		sh.point++;
		sh.count = true;
		sh.StopAllCoroutines();
	}
}

