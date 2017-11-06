using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public GameObject laserShot;
	public float xSpeed = 5f;
	public float ySpeed = 5f;
	public float xMin;
	public float xMax;
	public float padding = 1f;
	public float laserSpeed = 10f;
	public float fireRate = 0.2f;

	// Use this for initialization
	void Start()
	{
		float disance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, disance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, disance));
		xMin = leftmost.x + padding;
		xMax = rightmost.x - padding;
	}

	// Update is called once per frame
	void Update()
	{
		GetInput();
	}

	void GetInput()
	{
		//Checks for laser fire.
		if (Input.GetKeyDown(KeyCode.Space))
		{
			InvokeRepeating("FireLaser", 0.00001f, fireRate);
		}
		if (Input.GetKeyUp(KeyCode.Space))
		{
			CancelInvoke("FireLaser");
		}

		//if-else if statements to get either left or right arror keys to move position left or right. 
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position += Vector3.left * xSpeed * Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += Vector3.right * xSpeed * Time.deltaTime;
		}

		//Restricts player to xMin/xMax positions.
		float newX = Mathf.Clamp(transform.position.x, xMin, xMax);
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}

	void FireLaser()
	{
		GameObject laser = Instantiate(laserShot, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity, transform.parent);

		laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserSpeed, 0);
	}


}
