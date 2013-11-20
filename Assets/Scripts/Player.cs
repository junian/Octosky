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

		if(shoot)
		{
			Weapon weapon = GetComponent<Weapon>();
			if(weapon!=null)
			{
				weapon.Attack(false);
			}
		}
	}
}
