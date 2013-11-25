using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public Weapon[] weapon;
	public int touchDamage = 1;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 10.0f);
		weapon = this.GetComponentsInChildren<Weapon>();
	}
	
	// Update is called once per frame
	void Update () {
		if(weapon != null)
		{
			foreach(var w in weapon)
				w.Attack(true);
			SfxPlayer.Instance.MakeEnemyShotSound();
		}

		var dist = (transform.position - Camera.main.transform.position).z;
		
		var leftBorder   = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
		//var rightBorder  = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
		var topBorder    = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
		var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;
		
		if(transform.position.x < leftBorder - 10.0f || transform.position.y < topBorder || transform.position.y>bottomBorder)
			Destroy(gameObject);
	}

}
