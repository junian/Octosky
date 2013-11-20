using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public int hp = 100;
	public bool isEnemy = true;

	void OnTriggerEnter2D(Collider2D collider)
	{
		Bullet bullet = collider.gameObject.GetComponent<Bullet>();
		if(bullet != null)
		{
			if(bullet.isEnemyShot != isEnemy)
			{
				hp = Mathf.Max(0, hp - bullet.damage);
				Destroy(bullet.gameObject);
				if(hp <= 0)
				{
					Destroy(gameObject);
				}
			}
			return;
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(!isEnemy)
		{
			Enemy enemy = collision.collider.gameObject.GetComponent<Enemy>();
			if(enemy != null)
			{
				hp = Mathf.Max(0, hp - enemy.touchDamage);
				if(hp <= 0)
				{
					Destroy(gameObject);
				}
			}
			return;
		}
	}

	void OnGUI()
	{
		if(isEnemy)
		{
			//GUI.Box (new Rect (Screen.width - 100,0,100,50), "HP: " + hp);
		}
		else
		{
			GUI.Box (new Rect (0,0,100,50), "HP: " + hp);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
