using UnityEngine;
using System.Collections;

public class GameOverHandler : MonoBehaviour {

	void OnGUI()
	{
		const int buttonWidth = 120;
		const int buttonHeight = 60;

		if(GUI.Button(
			new Rect((Screen.width - buttonWidth)/2.0f,
		         Screen.height/3.0f - buttonHeight/2.0f,
		         buttonWidth,
		         buttonHeight), "Play Again!"))
		{
			Application.LoadLevel(Scenes.Game);
		}

		if(GUI.Button(
			new Rect((Screen.width - buttonWidth)/2.0f,
		         2.0f*Screen.height/3.0f - buttonHeight/2.0f,
		         buttonWidth,
		         buttonHeight), "Main Menu"))
		{
			Application.LoadLevel(Scenes.Menu);
		}
	}
}
