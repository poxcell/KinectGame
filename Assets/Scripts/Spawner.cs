using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

	public GameObject fallingPrefab;
	public Vector2 secondsBetweenSpawnMinMax ;
	float nextSpawnTime;

	public float spawnSize;

	public float spawnAngleMax;
	public List<GameObject> items = new List<GameObject> ();

	private bool pausa = false;

	Vector2 screenHalfSizeWorldUnits;
    // Start is called before the first frame update
    void Start()
    {
		screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);   
    }

    // Update is called once per frame
    void Update()
    {
		if (!pausa)
		{
			if (Time.time > nextSpawnTime)
			{
				float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnMinMax.y, secondsBetweenSpawnMinMax.x, dificultad.GetDifficultyPercent());

				nextSpawnTime = Time.time + secondsBetweenSpawns;

				float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);

				Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnSize);
				GameObject newBlock = (GameObject)Instantiate(fallingPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
				newBlock.transform.localScale = Vector3.one * spawnSize;

				items.Add((newBlock) as GameObject);
			}

			for (var i = items.Count - 1; i > -1; i--)
			{
				if (items[i] == null)
					items.RemoveAt(i);
			}
		}
	}
	public void pauseBlocks()
	{
		for (var i = items.Count - 1; i > -1; i--)
		{
			items[i].GetComponent<FallingObjects>().pausar();
		}
		pausa = true;
	}
	public void unPauseblocks()
	{
		for (var i = items.Count - 1; i > -1; i--)
		{
			items[i].GetComponent<FallingObjects>().despausar();
		}
		pausa = false;
	}
}
