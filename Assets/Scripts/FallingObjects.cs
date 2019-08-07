using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjects : MonoBehaviour
{
	public Vector2 speedMinMax;
	float speed ;
	private  bool pausado;
	// Update is called once per frame

	void Start()
	{
		speed = Mathf.Lerp(speedMinMax.y, speedMinMax.x, dificultad.GetDifficultyPercent());
		pausado = false;
	}
	void Update()
    {
		if (Time.timeScale > 0)
		{
			if (!pausado)
			{
				transform.Translate(Vector3.down * speed * Time.deltaTime);
			}
		}
    }
	public void pausar()
	{
		pausado = true;
	}
	public void despausar()
	{
		pausado = false;
	}
}
