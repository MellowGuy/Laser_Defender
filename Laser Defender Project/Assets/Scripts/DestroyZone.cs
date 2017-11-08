using UnityEngine;

public class DestroyZone : MonoBehaviour {

	//Destroys objects that enter collider box, keeps laser fire from existing indefinately.
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Destroy(collision.gameObject);
	}
}
