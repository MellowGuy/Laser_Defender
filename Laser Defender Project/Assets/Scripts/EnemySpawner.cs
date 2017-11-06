using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject enemyPrefab;
	public float width = 10f;
	public float height = 5f;
	public float speed = 5f;
	public float xMin;
	public float xMax;

	private bool movingRight = false;

	// At start, runs foreach transform in the spawners transform, spawns enemy at that position
	void Start()
	{
		float distanceToCamera = transform.position.z - Camera.main.transform.position.z;

		Vector3 leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
		Vector3 rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));

		Debug.LogWarningFormat("LeftBounds:{0}|RightBounds:{1}", leftBoundary, rightBoundary);


		xMin = leftBoundary.x;
		xMax = rightBoundary.x;

		Debug.LogFormat("Child Count: " + transform.childCount);

		foreach (Transform item in transform)
		{
			GameObject enemy = Instantiate(enemyPrefab, item.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = item;
			Debug.LogFormat("Enemy Spwaned at: {0}, {1}.", item.position.x, item.position.y);
		}
	}




	// Update is called once per frame
	void Update()
	{
		if (movingRight)
		{
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		else
		{
			transform.position += Vector3.left * speed * Time.deltaTime;
		}

		float leftEdgeOfFormation = transform.position.x - (0.5f * width);
		float rightEdgeOfFormation = transform.position.x + (0.5f * width);


		if (leftEdgeOfFormation < xMin)
		{
			movingRight = true;
		}

		else if (rightEdgeOfFormation > xMax)
		{
			movingRight = false;
		}
	}

	public void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
	}
}
