using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjects : MonoBehaviour
{
	public Vector2 speedMinMax;
	float speed ;
	// Update is called once per frame

	void Start()
	{
		speed = Mathf.Lerp(speedMinMax.y, speedMinMax.x, dificultad.GetDifficultyPercent());	
	}
	void Update()
    {
		transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
