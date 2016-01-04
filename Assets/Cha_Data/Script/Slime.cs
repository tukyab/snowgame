using UnityEngine;
using System.Collections;

public class Slime : MonoBehaviour {

	int health = 5;
	public Animation SlimeAnimator; 
	public GameObject projectile;
	public AudioClip attackSound;
	public AudioClip deathSound;
	int time = 0;
	AudioSource ActionAudio;
	public GameObject knight;

	// Use this for initialization
	void Start () {
		SlimeAnimator = GetComponent<Animation> ();
		ActionAudio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		time += 1;

		if (time % 10000 == 99)
		{
			Vector3 position= new Vector3(knight.transform.position.x, knight.transform.position.y, knight.transform.position.z);  
			Vector3 startPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 20, gameObject.transform.position.z);
			
			GameObject snowball= Instantiate (projectile, startPos, Quaternion.identity) as GameObject; 
			snowball.transform.LookAt(position); 
			snowball.AddComponent<Rigidbody>();
			snowball.GetComponent<Rigidbody>().AddForce(snowball.transform.forward *5000); 
			ActionAudio.clip = attackSound;
			ActionAudio.Play();
			SlimeAnimator.Play ("Attack");
		}
		else {
			SlimeAnimator.Play ("Wait");
		}
	}

	void OnTriggerEnter(Collider other) {
		health -= 1;
		SlimeAnimator.Play ("Damage");
		if (health == 0) {
			ActionAudio.clip = deathSound;
			ActionAudio.Play();
			SlimeAnimator.Play("Dead");
			Destroy (gameObject);
		}
		Destroy (other.gameObject);
	}
}
