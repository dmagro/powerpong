using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SpawnPowersScript : MonoBehaviour 
{
	public List<Transform> powersPrefabs;
	public float spawnWait;
	public float startWait;

	private float numberOfPrefabs;
	
	void Start () {
		numberOfPrefabs = powersPrefabs.Count;
		StartCoroutine(spawnPowers());
	}

	private IEnumerator spawnPowers()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			spawnPower();
			yield return new WaitForSeconds (spawnWait);
		}
	}

	private void spawnPower()
	{
		int powerIndex = getIndex();
		createPower(powerIndex);
	}

	private int getIndex()
	{
		float randomNumber = Random.Range(0.0f, numberOfPrefabs-1.0f);
		return Mathf.RoundToInt(randomNumber);
	}

	private void createPower(int powerIndex)
	{
		Transform powerPrefab = powersPrefabs[powerIndex];
		var powerTransform = Instantiate(powerPrefab) as Transform;
		setPowerRandomPosition(powerTransform);
	}

	private void setPowerRandomPosition(Transform powerTransform)
	{
		Tuple<float, float, float, float> cameraBorders = Utilities.getCameraBorders(transform);
		
		float leftBorder = cameraBorders.Item1;
		float rightBorder = cameraBorders.Item2;
		float topBorder = cameraBorders.Item3;
		float bottomBorder = cameraBorders.Item4;

		float randomFloat = Random.Range(0.0f, 1.0f);
		int randomInt = Mathf.RoundToInt(randomFloat);

		bool isPlayer1 = randomInt == 1 ? true : false;
		
		Tuple<float, float, float, float> playerBorders = Utilities.getPlayerHorizontalBorders(leftBorder, rightBorder, isPlayer1);

		float x = Random.Range(playerBorders.Item1, playerBorders.Item2);
		float y = Random.Range(bottomBorder, topBorder);

		powerTransform.position = new Vector3(x, y, 0);
	}


}
