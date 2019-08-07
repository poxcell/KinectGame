using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHand : MonoBehaviour
{
	public GameObject leftHand;
	public GameObject rightHand;
	
	private Vector2 direction;

	public float moveSpeed = 100f;


	void Start()
	{
		
	}


	// Update is called once per frame
	void Update()
    {
		
		float vectorx = rightHand.transform.position.x + (leftHand.transform.position.x - rightHand.transform.position.x) / 2;
		float vectory = rightHand.transform.position.y + (leftHand.transform.position.y - rightHand.transform.position.y) / 2;
		Vector3 targetPosition = new Vector3(vectorx, vectory, 0);

		direction = Vector3.Lerp(transform.position, targetPosition, moveSpeed *Time.deltaTime);

		transform.position = direction;
		
	}
}
