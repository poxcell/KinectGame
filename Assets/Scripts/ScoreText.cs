using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreText : MonoBehaviour
{
	
	public Text scoreText;

	// Update is called once per frame
	public void ChangeScore(int number)
	{
		scoreText.text = "Score : " + number.ToString();
	}
}
