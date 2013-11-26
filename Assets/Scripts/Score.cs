using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public static Score Instance;
	public int score;

	// Use this for initialization
	void Start () {
		if(Instance != null)
		{
			print("too many instance");
		}
		Instance = this;
		score = 0;
	}

	void OnGUI()
	{
		GUI.Box (new Rect (Screen.width - 100,0,100,50), "Score: " + score);
	}
}
