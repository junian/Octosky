using UnityEngine;
using System.Collections;

public class SfxPlayer : MonoBehaviour {

	public static SfxPlayer Instance;

	public AudioClip explosionSound;
	public AudioClip playerShotSound;
	public AudioClip enemyShotSound;

	void Awake()
	{
		if(Instance != null)
		{
			print("too many instance");
		}
		Instance = this;
	}

	public void MakeExplosionSound()
	{
		MakeSound(explosionSound);
	}
	
	public void MakePlayerShotSound()
	{
		MakeSound(playerShotSound);
	}
	
	public void MakeEnemyShotSound()
	{
		MakeSound(enemyShotSound);
	}

	private void MakeSound(AudioClip audioClip)
	{
		AudioSource.PlayClipAtPoint(audioClip, transform.position);
	}
}
