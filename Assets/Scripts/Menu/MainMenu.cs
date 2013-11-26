using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	private GUISkin skin;

	void Start()
	{
		skin = Resources.Load<GUISkin>("GUISkin");
	}

	void OnGUI()
	{
		const int buttonWidth = 84;
		const int buttonHeight = 60;
		GUI.skin = skin;
		if(GUI.Button(
			new Rect(
				(Screen.width - buttonWidth) / 2.0f, 
				(2.0f * Screen.height / 3.0f) - (buttonHeight / 2.0f),
		         buttonWidth,
		         buttonHeight),
			"Begin!"))
		{
			Application.LoadLevel(Scenes.Game);
		}
	}
}
