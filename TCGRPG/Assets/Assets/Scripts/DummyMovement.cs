﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyMovement : MonoBehaviour {

	public float moveForce;
	private Rigidbody rbody;
	public Vector3 moveDir;
	public LayerMask whatIsWall;
	public float maxDistFromWall;

	void Start(){

		rbody = GetComponent<Rigidbody> ();
		moveDir = ChooseDirection ();
		transform.rotation = Quaternion.LookRotation (moveDir);

	}		
	
	// Update is called once per frame
	void Update () {

		rbody.velocity = moveDir * moveForce;

		if (Physics.Raycast (transform.position, transform.forward, maxDistFromWall, whatIsWall)) {

			moveDir = ChooseDirection ();
			transform.rotation = Quaternion.LookRotation (moveDir);
		}

	}

	Vector3 ChooseDirection(){
		System.Random ran = new System.Random ();
		int i = ran.Next (0, 3);
		Vector3 temp = new Vector3 ();

		if (i == 0) {
			temp = transform.forward;
		} else if (i == 1) {
			temp = -transform.forward;
		} else if (i == 2) {
			temp = transform.right;
		} else if (i == 3) {
			temp = -transform.right;
		}

		return temp;
	}
}
