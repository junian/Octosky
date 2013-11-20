using UnityEngine;
using System.Collections;

public class LinearMove : MonoBehaviour {
	public Vector2 speed =new Vector2(10.0f, 10.0f);
	public Vector2 direction = new Vector2(-1.0f, 0.0f);

	// Update is called once per frame
	void Update () {
		Vector3 movement = new Vector3(
			speed.x * direction.x,
			speed.y * direction.y,
			0.0f);
		movement = movement * Time.deltaTime;
		transform.Translate(movement);
	}
}
