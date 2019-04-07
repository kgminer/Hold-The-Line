using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense : MonoBehaviour
{
	Renderer defenseRenderer;
	private int counter = 0;
	private Color newColor;

    void Start()
    {
        // This allows us to change the defense wall's color
        defenseRenderer = GetComponent<Renderer>();
		
		// To change the stating color
		//defenseRenderer.material.color = Color.this[0,0,0,0];
    }

	void OnCollisionEnter(Collision impact) 
	{
		// Shows the amount of damage taken by the ball
		if(impact.gameObject.tag == "Boulder")
		{
			if(impact.gameObject.GetComponent<Ball>().GetIncreasedDamage())
			{
                if (!GameManager.suddenDeath)
                {
                    ++counter;
                    impact.gameObject.GetComponent<Ball>().SetIncreasedDamage(false);
                }
                else
                {
                    ++counter;
                }
            }
			
			switch(++counter)
			{
				case 1:
					newColor.a = 1.0f;
					newColor.b = 0.65f;
					newColor.g = 0.65f;
					newColor.r = 0.65f;
					defenseRenderer.material.color = newColor;
					break;
				case 2:
					newColor.a = 1.0f;
					newColor.b = 0.35f;
					newColor.g = 0.35f;
					newColor.r = 0.35f;
					defenseRenderer.material.color = newColor;
					break;
				case 3:
					newColor.a = 1.0f;
					newColor.b = 0.1f;
					newColor.g = 0.1f;
					newColor.r = 0.1f;
					defenseRenderer.material.color = newColor;
					break;
                default:
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
