using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
	public float health = 200f;
	public float laserSpeed = 10f;
	public GameObject laserShot;
	public float shotsPerSecond = 0.5f;

	private void Update()
	{
		float probability = Time.deltaTime * shotsPerSecond;
		if (Random.value < probability)
		{
			FireLaser();
		}
	}

	void FireLaser()
	{
		GameObject enemyShot = Instantiate(laserShot, new Vector3(transform.position.x, transform.position.y - 1f, 0f), Quaternion.identity, transform.parent) as GameObject;
		enemyShot.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laserSpeed);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		LaserFire laser = collision.gameObject.GetComponent<LaserFire>();

		if (laser)
		{
			laser.Hit();
			health -= laser.GetDamage();

			if (health <= 0)
			{
				Destroy(gameObject);
				Debug.Log("destroyed!!!");
			}
		}
	}
}