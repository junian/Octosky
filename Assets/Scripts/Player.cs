using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public Vector2 speed = new Vector2(50.0f, 50.0f);

	// Use this for initialization
	void Update () {
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(
			speed.x * inputX,
			speed.y * inputY,
			0.0f);

		movement = movement * Time.deltaTime;
		transform.Translate(movement);

		bool shoot = Input.GetButtonDown("Fire1");
		shoot |= Input.GetButtonDown("Fire2");
		shoot |= Input.touchCount > 0;

		if(shoot)
		{
			Weapon weapon = GetComponent<Weapon>();
			if(weapon!=null)
			{
				weapon.Attack(false);
				SfxPlayer.Instance.MakePlayerShotSound();
			}
		}

		KeepPlayerInsideCamera();
	}

	void KeepPlayerInsideCamera()
	{
		var dist = (transform.position - Camera.main.transform.position).z;

		var leftBorder   = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
		var rightBorder  = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
		var topBorder    = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
		var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;

		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
			Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
			transform.position.z);
	}

	void OnDestroy()
	{
		transform.parent.gameObject.AddComponent<GameOverHandler>();
	}
}
