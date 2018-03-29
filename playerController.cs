using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(playerMotor))]
public class playerController : MonoBehaviour {

	public LayerMask movementMask;
	playerMotor motor;
	Camera cam;
	public bool publicPlayer;
	public bool selected;	//this will be true if the player is selected
	Vector3 destination;
	// Use this for initialization
	void Start () {
		cam = Camera.main;
		motor = GetComponent<playerMotor>();
	}
	
	// Update is called once per frame
	void Update () {
		if(selected)
		{
			if(Input.GetMouseButtonDown(0))
			{
				Ray ray = cam.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				Debug.Log("here");
				if(Physics.Raycast(ray, out hit))
				{
					destination = hit.point;
					Debug.Log("hit " + hit.collider.name + " " + destination);
					if (hit.collider.name != GetComponent<Collider>().name)
					{
						motor.MoveToPoint(destination);
						selected = false;
					}
				}
			}
		}
	}
}
