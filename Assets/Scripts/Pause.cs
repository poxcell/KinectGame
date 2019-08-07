using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
	private bool paused = false;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (paused)
				Time.timeScale = 1;
			else
				Time.timeScale = 0;
			paused = !paused;
		}
	}

	void OnTriggerEnter2D(Collider2D triggerCollider)
	{
		if (triggerCollider.tag == "Player")
		{
			Time.timeScale = 0;
		}
	}
}
