using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
	private bool paused = false;
	private bool entered = false;
	public GameObject Player;
	private float timer = 0;
	private float currentTime;
	private bool hasExited = true;
	
	void Update()
	{
		if (hasExited)
		{
			if (!paused)
			{
				if (entered)
				{
					if (timer < 2)
					{
						timer += Time.deltaTime;
					}
					else
					{
						pauseGame();
						hasExited = false;
						paused = true;
					}
				}

			}
			else
			{
				if (entered)
				{
					if (timer < 2)
					{
						timer += Time.deltaTime;
					}
					else
					{
						unPauseGame();
						hasExited = false;
						paused = false;
					}
				}
			}


		}
		
		
		
	}

	void pauseGame()
	{
		Debug.Log("paused");
	}

	void unPauseGame()
	{
		Debug.Log("unpaused");
	}

	void OnTriggerEnter2D(Collider2D triggerCollider)
	{
		
		if ( triggerCollider.tag == "manoIzquierda" || triggerCollider.tag == "manoDerecha")
		{
			entered = true;

		}
	}

	void OnTriggerExit2D(Collider2D triggerCollider)
	{

		if (triggerCollider.tag == "manoIzquierda" || triggerCollider.tag == "manoDerecha")
		{
			entered = false;
			timer = 0;
			hasExited = true;
		}
	}

}
