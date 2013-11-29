using UnityEngine;
using System.Collections.Generic;

public class GameOverHandler : MonoBehaviour {

	void OnGUI()
	{
		const int buttonWidth = 120;
		const int buttonHeight = 60;

		if(GUI.Button(
			new Rect((Screen.width - buttonWidth)/2.0f,
		         0.5f * Screen.height/3.0f - buttonHeight/2.0f,
		         buttonWidth,
		         buttonHeight), "Play Again!"))
		{
			Application.LoadLevel(Scenes.Game);
		}

		if(GUI.Button(
			new Rect((Screen.width - buttonWidth)/2.0f,
		         1.5f*Screen.height/3.0f - buttonHeight/2.0f,
		         buttonWidth,
		         buttonHeight), "Main Menu"))
		{
			Application.LoadLevel(Scenes.Menu);
		}

		if(FB.IsLoggedIn)
		{
			if(GUI.Button(
				new Rect((Screen.width - buttonWidth)/2.0f,
			         2.5f*Screen.height/3.0f - buttonHeight/2.0f,
			         buttonWidth,
			         buttonHeight), "Facebook Post"))
			{
				int score = Score.Instance.score;
				
				var scoreData = new Dictionary<string, string>() {{"score", score.ToString()}};
				
				FB.API ("/me/scores", Facebook.HttpMethod.POST, null, scoreData);
				FB.Feed(                                                                                                                 
				        linkCaption: "Wow, I got " + score + " score! Can you beat it?",               
				        picture: "https://lh4.googleusercontent.com/-56qYIvZaD8k/UFw8MQuaRPI/AAAAAAAABBs/l3i2s75YB0M/s800/juniannet.png",                                                     
				        linkName: "Beat me if you can!",                                                                 
				        link: "https://apps.facebook.com/" + FB.AppId + "/?challenge_brag=" + (FB.IsLoggedIn ? FB.UserId : "guest")       
				        );
			}
		}
	}
}
