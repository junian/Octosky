using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public int hp = 100;
	public bool isEnemy = true;
	public GameObject particle;

	void OnTriggerEnter2D(Collider2D collider)
	{
		if(!this.renderer.IsVisibleFrom(Camera.main))
		   return;

		Bullet bullet = collider.gameObject.GetComponent<Bullet>();
		if(bullet != null)
		{
			if(bullet.isEnemyShot != isEnemy)
			{
				hp = Mathf.Max(0, hp - bullet.damage);
				Destroy(bullet.gameObject);
				if(hp <= 0)
				{
					if(particle != null)
					{
						GameObject part = (GameObject) Instantiate(particle, transform.position, Quaternion.identity);
						var p = part.GetComponent<ParticleSystem>();
						Destroy(part, p.startLifetime);
					}

					SfxPlayer.Instance.MakeExplosionSound();

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
					if(particle != null)
					{
						GameObject part = (GameObject) Instantiate(particle, transform.position, Quaternion.identity);
						var p = part.GetComponent<ParticleSystem>();
						Destroy(part, p.startLifetime);
					}

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
