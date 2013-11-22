using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ParallaxScroll : MonoBehaviour {

	public Vector2 speed = new Vector2(2.0f, 2.0f);
	public Vector2 direction = new Vector2(-1.0f, 0.0f);
	public bool isLinkedToCamera = false;
	public bool isLooping = false;
	private List<Transform> backgroundPart;

	// Use this for initialization
	void Start () {
		backgroundPart = new List<Transform>();
		for(int i=0; i< transform.childCount;i++)
		{
			Transform child = transform.GetChild(i);
			if(child.renderer != null)
			{
				backgroundPart.Add(child);
			}
			backgroundPart = backgroundPart.OrderBy(t => t.position.x).ToList();
		}
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 movement = new Vector3(
			speed.x * direction.x,
			speed.y * direction.y,
			0.0f);

		movement *= Time.deltaTime;
		transform.Translate(movement);

		if(isLinkedToCamera)
		{
			Camera.main.transform.Translate(movement);
		}

		if(isLooping)
		{
			Transform firstChild = backgroundPart.FirstOrDefault();
			if(firstChild != null)
			{
				if(!firstChild.renderer.IsVisibleFrom(Camera.main))
				{
					Transform lastChild = backgroundPart.LastOrDefault();
					Vector3 lastPosition = lastChild.position;
					Vector3 lastSize = lastChild.renderer.bounds.max - lastChild.renderer.bounds.min;

					firstChild.position = new Vector3(lastPosition.x + lastSize.x,
					                                  firstChild.position.y,
					                                  firstChild.position.z);
					backgroundPart.Remove(firstChild);
					backgroundPart.Add(firstChild);
				}
			}
		}
	
	}
}
