﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	
	void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Hit - " + col.gameObject.name);
    }
}
