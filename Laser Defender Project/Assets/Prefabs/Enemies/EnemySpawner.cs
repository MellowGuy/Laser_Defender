using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	private bool movingRight = false;

	public GameObject enemyPrefab;
	public float width = 10f;
	public float height = 5f;
	public float speed = 5f;
	public float xMin;
	public float xMax;
	public float spawnDelay = 5f;

	// At start, runs foreach transform in the spawners transform, spawns enemy at that position
	void Start()
	{
		float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
		//Calculates play space and sets left and right x axis boundaries
		Vector3 leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
		Vector3 rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));

		Debug.LogWarningFormat("LeftBounds:{0}|RightBounds:{1}", leftBoundary, rightBoundary);

		xMin = leftBoundary.x;
		xMax = rightBoundary.x;
		
		SpawnUntilFull();
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

		//swaps moving right back and forth
		if (leftEdgeOfFormation < xMin)
			movingRight = true;
		
		else if (rightEdgeOfFormation > xMax)
			movingRight = false;
		
		//Checks if all enemies are dead.
		if (AllMembersDead())
		{
			Debug.Log("ALl enemies dead.");
			SpawnUntilFull();
		}
	}



	//returns a position if it's child is empty
	Transform NextFreePosition()
	{
		foreach (Transform childPositionGameObject in transform)
		{
			if (childPositionGameObject.childCount == 0)
				return childPositionGameObject;
		}
		return null;
	}

	//spawns enemies at next free position. Method calls itself recursively if there's a free position after spawnDelay.
	void SpawnUntilFull()
	{
		Transform freePosition = NextFreePosition();

		if (freePosition != null)
		{
			GameObject enemy = Instantiate(enemyPrefab, freePosition.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePosition;
			Debug.LogFormat("Enemy Spwaned at: {0}, {1}.", freePosition.position.x, freePosition.position.y);
		}

		if (NextFreePosition() != null)
		{
			Invoke("SpawnUntilFull", spawnDelay * Time.deltaTime);
		}
	}

	//Checks if all child memebers of position in EnemySpawer are empty or not.
	public bool AllMembersDead()
	{
		foreach (Transform childPositionGameObject in transform)
		{
			if (childPositionGameObject.childCount > 0)
				return false;
		}

		return true;
	}

	//Puts wire cube on enemy spawner
	public void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
	}



	/*//Unused code was for spawning enemy objects.
public void SpawnAllEnemies()
{
	foreach (Transform item in transform)
	{
		GameObject enemy = Instantiate(enemyPrefab, item.transform.position, Quaternion.identity) as GameObject;
		enemy.transform.parent = item;
		Debug.LogFormat("Enemy Spwaned at: {0}, {1}.", item.position.x, item.position.y);
	}
}
*/
}
