using UnityEngine;

public class PositionViewer : MonoBehaviour {
	//Just enables Gizmo on position object to see enemy position without actually being spawned
	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(transform.position, 1);
	}
}
