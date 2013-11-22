using UnityEngine;
using System.Collections;

public class EnemyWave : MonoBehaviour {

	public GameObject enemy;
	public int minEnemy = 1;
	public int maxEnemy = 3;
	public Vector2 randomRange = new Vector2(5,5);
	public float spawnTime = 1.0f;
	public float minWeaponSpawn = 1.5f;
	public float maxWeaponSpawn = 3.0f;
	private float currentTime;
	// Use this for initialization
	void Start () {
		currentTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		currentTime = Mathf.Max(0.0f, currentTime - Time.deltaTime);
		GenerateWave();
	}

	void GenerateWave()
	{
		if(currentTime <= 0.0f)
		{
			currentTime = spawnTime;

			int enemiesCount = Random.Range(minEnemy, maxEnemy);

			for(int i=0;i<enemiesCount;i++)
			{
				GameObject obj = (GameObject) Instantiate(enemy);
				float x = Random.Range(-randomRange.x, randomRange.x);
				float y = Random.Range(-randomRange.y, randomRange.y);

				Vector3 position = new Vector3(
					this.transform.position.x + x,
					this.transform.position.y + y,
					this.transform.position.z);

				obj.transform.position = position;

				Weapon[] wps = obj.GetComponentsInChildren<Weapon>();
				if(wps != null)
				{
					foreach(var wp in wps)
					{
						wp.shootingRate = Random.Range(minWeaponSpawn, maxWeaponSpawn);
					}
				}
			}
		}
	}
}
