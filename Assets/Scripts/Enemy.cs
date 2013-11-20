using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int touchDamage = 1;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 20.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
