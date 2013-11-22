using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public GameObject bullet;
	public float shootingRate = 0.25f;

	private float shootCooldown;

	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0.0f;
		}
	}

	// Use this for initialization
	void Start () {
		shootCooldown = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		shootCooldown = Mathf.Max(0.0f, shootCooldown - Time.deltaTime);
	}

	public void Attack(bool isEnemy)
	{
		if(CanAttack)
		{
			shootCooldown = shootingRate;

			GameObject objBullet = (GameObject) Instantiate(bullet);
			objBullet.transform.position = transform.position;

			Bullet mBullet = objBullet.GetComponent<Bullet>();
			if(mBullet != null)
			{
				mBullet.isEnemyShot = isEnemy;
			}

			LinearMove move = objBullet.GetComponent<LinearMove>();
			if(move != null)
			{
				//if(!isEnemy)
					move.direction = this.transform.right;
				//else
					//move.direction = -this.transform.right;

			}
		}
	}
}
