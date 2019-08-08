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

	public float pauseTime = 2;
	public GameObject spawner;
	
	void Awake()
	{
		
	}

	void Update()
	{
		if (hasExited)
		{
			if (!paused)
			{
				if (entered)
				{
					if (timer < pauseTime)
					{
						timer += Time.deltaTime;
						gameObject.GetComponent<Renderer>().material.color = new Color(((timer / 2)) + .1f, .4f, .41f, ((timer / 2)) + .1f);
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
					if (timer < pauseTime)
					{
						float cur = pauseTime;
						
						timer += Time.deltaTime;
						cur -= timer;
						gameObject.GetComponent<Renderer>().material.color = new Color(((cur / 2)) + .1f, .4f, .41f, ((cur / 2) )+ .1f);
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
		spawner.GetComponent<Spawner>().pauseBlocks();
		Player.GetComponent<FollowHand>().pausar();
	}

	void unPauseGame()
	{
		spawner.GetComponent<Spawner>().unPauseblocks();
		Player.GetComponent<FollowHand>().despausar();
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
