﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public int damage = 10;
	public bool isEnemyShot = false;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 10.0f);
	}
	
	// Update is called once per frame
	void Update () {
		var dist = (transform.position - Camera.main.transform.position).z;

		var leftBorder   = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
		//var rightBorder  = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
		var topBorder    = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
		var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;

		if(transform.position.x < leftBorder || transform.position.y < topBorder || transform.position.y>bottomBorder)
			Destroy(gameObject);

	}

}
