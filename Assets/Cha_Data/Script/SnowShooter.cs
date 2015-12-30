using UnityEngine;
using System.Collections;

public class SnowShooter : MonoBehaviour
{
	public Rigidbody projectile;
	public float speed = 40;
	float loadRate = 0.5f; // how often a new projectile can be fired
	float timeRemaining; // how much time before the next shot can happen

	
	// Update is called once per frame
	void Update ()
	{
		timeRemaining -= Time.deltaTime;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); 
		if (Input.GetButton("Fire1")&& timeRemaining <= 0 && Physics.Raycast(ray))
		{
			timeRemaining = loadRate; 
			Rigidbody snowball = Instantiate(projectile,transform.position,transform.rotation)as Rigidbody;
			snowball.velocity = transform.TransformDirection(new Vector3(0, 0,speed));
		}
	}
}
