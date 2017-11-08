using UnityEngine;

public class LaserFire : MonoBehaviour {

	public float damage = 100f;

	//Laser objects, return set damage.
	public float GetDamage()
	{
		return damage;
	}
	
	//Destroys laser on hit.
	public void Hit()
	{		
		Destroy(gameObject);
	}

}
