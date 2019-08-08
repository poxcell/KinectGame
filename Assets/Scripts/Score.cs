using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
	public GameObject scoreText;
	private int score = 0;
	public void sumScore(){
		score++;
		getScore();
	}
	private void getScore()
	{
		scoreText.GetComponent<ScoreText>().ChangeScore(score);
	}

}
