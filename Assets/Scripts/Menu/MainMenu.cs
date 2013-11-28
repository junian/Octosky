using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	private GUISkin skin;

	private void InitFacebook()
	{
		FbDebug.Log("Facebook init");

		enabled = true;
		if(FB.IsLoggedIn)
		{
			FbDebug.Log ("already login");
			OnFBLoggedIn();
		}
	}

	private void OnHideUnity(bool isGameShown)
	{
		FbDebug.Log("On Hide Unity");
		if(!isGameShown)
		{
			Time.timeScale = 0.0f;
		}
		else
		{
			Time.timeScale = 1.0f;
		}
	}

	void LoginCallback(FBResult result)
	{
		FbDebug.Log("Login callback");
		if(FB.IsLoggedIn)
		{
			OnFBLoggedIn();
		}
	}

	void OnFBLoggedIn()
	{
		FbDebug.Log("Logged in. ID: " + FB.UserId); 
	}

	void Awake()
	{
		enabled = false;
		FB.Init(InitFacebook, OnHideUnity);
	}

	void Start()
	{
		skin = Resources.Load<GUISkin>("GUISkin");
	}

	void OnGUI()
	{
		const int buttonWidth = 128;
		const int buttonHeight = 60;
		Rect rect = new Rect(
			(Screen.width - buttonWidth) / 2.0f, 
			(2.0f * Screen.height / 3.0f) - (buttonHeight / 2.0f),
			buttonWidth,
			buttonHeight);
			
		//GUI.skin = skin;
		if(FB.IsLoggedIn)
		{
			if(GUI.Button(
				rect,
				"Begin!"))
			{
				Application.LoadLevel(Scenes.Game);
			}
		}
		else
		{
			if(GUI.Button(
				rect,
				"Facebook Login"))
			{
				FB.Login("email,publish_actions", LoginCallback);
			}
		}
	}
}
