﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{

	private Vector3 mousePosition;
	private Rigidbody2D rb;
	private Vector2 direction;
	public float moveSpeed = 100f;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		direction = (mousePosition - transform.position).normalized;
		rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);

	}

	void OnTriggerEnter2D(Collider2D triggerCollider)
	{
		if(triggerCollider.tag == "Falling Item")
		{
			Destroy(triggerCollider.gameObject);
			GetComponent<Score>().sumScore();
		}
	}
}
