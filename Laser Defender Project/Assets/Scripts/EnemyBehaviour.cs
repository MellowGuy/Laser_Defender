using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
	public float health = 200f;
	public float laserSpeed = 10f;
	public GameObject laserShot;
	public float shotsPerSecond = 0.5f;
	public int scoreValue = 1000;

	private ScoreKeeper scoreKeeper;

	//Gets reference to text object "Score" dynamically. 
	private void Start()
	{
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}

	//Randomizes shooting of enemies
	private void Update()
	{
		float probability = Time.deltaTime * shotsPerSecond;
		if (Random.value < probability)
		{
			FireLaser();
		}
	}

	//FireLaser creates laser game object w/ velocity
	void FireLaser()
	{
		GameObject enemyShot = Instantiate(laserShot, new Vector3(transform.position.x, transform.position.y - 1f, 0f), Quaternion.identity, transform.parent) as GameObject;
		enemyShot.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laserSpeed);
	}

	//Collisions with this enemy
	private void OnTriggerEnter2D(Collider2D collision)
	{
		//gets reference to LaserFire type object if is collision
		LaserFire laser = collision.gameObject.GetComponent<LaserFire>();

		//if not null object
		if (laser != null)
		{
			//calls Hit() of the laser, gets damage amount and ups the score by enemy scoreValue
			laser.Hit();
			health -= laser.GetDamage();
			scoreKeeper.Score(scoreValue);

			if (health <= 0)
			{
				Destroy(gameObject);
				Debug.Log("destroyed!!!");
			}
		}
	}
}