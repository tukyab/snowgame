using UnityEngine;
using System.Collections;

public class SnowShooter : MonoBehaviour
{
	public GameObject projectile;
	public float speed = 40;
	float distance= 100.0f;
	float loadRate = 0.5f; // how often a new projectile can be fired
	float timeRemaining; // how much time before the next shot can happen

	
	// Update is called once per frame
	void Update ()
	{
		timeRemaining -= Time.deltaTime; 
		if (Input.GetButton("Fire1")&& timeRemaining <= 0)
		{
			timeRemaining = loadRate; 
			Vector3 position= new Vector3(Input.mousePosition.x, Input.mousePosition.y,distance);  
			position= Camera.main.ScreenToWorldPoint(position); 

			//Rigidbody snowball = Instantiate(projectile,transform.position,transform.rotation)as Rigidbody;
			GameObject snowball= Instantiate (projectile, transform.position, Quaternion.identity) as GameObject; 
			snowball.transform.LookAt(position); 
			snowball.GetComponent<Rigidbody>().AddForce(snowball.transform.forward *1000); 
			snowball.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0, 0,speed));
		}
	}
}
