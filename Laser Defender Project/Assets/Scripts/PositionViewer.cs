﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionViewer : MonoBehaviour {

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(transform.position, 1);
	}
}