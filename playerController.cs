using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(playerMotor))]
public class playerController : MonoBehaviour {

	public LayerMask movementMask;
	playerMotor motor;
	Camera cam;
	// Use this for initialization
	void Start () {
		cam = Camera.main;
		motor = GetComponent<playerMotor>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			Debug.Log("here");
			if(Physics.Raycast(ray, out hit))
			{
				Debug.Log("hit " + hit.collider.name + " " + hit.point);
				motor.MoveToPoint(hit.point);
			}
		}
	}
}
