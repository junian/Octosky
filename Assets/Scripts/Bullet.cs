using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public int damage = 10;
	public bool isEnemyShot = false;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 20);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
