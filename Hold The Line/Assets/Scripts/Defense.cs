﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense : MonoBehaviour
{
	Renderer defenseRenderer;
	private int counter = 0;

    void Start()
    {
        // This allows us to change the defense wall's color
        defenseRenderer = GetComponent<Renderer>();
    }

	void OnCollisionEnter(Collision impact) 
	{
		// Shows the amount of damage taken by the ball
		if(impact.gameObject.name == "Ball")
		{
			if(impact.gameObject.tag == "IncBallDmgPowerup")
			{
				++counter;
			}
			
			switch(++counter)
			{
				case 1:
					defenseRenderer.material.color = Color.green;
					break;
				case 2:
					defenseRenderer.material.color = Color.yellow;
					break;
				case 3:
					defenseRenderer.material.color = Color.red;
					break;
			}
		}
	}

	void Update()
	{
		// This removes the defense wall on the 4th hit
		if(counter >= 4)
		{
			Destroy(gameObject);
		}
	}
}
