using UnityEngine;
using System.Collections;

public class Snowman : MonoBehaviour {

	public GameObject projectile;
	public AudioClip throwingSound;
	int time = 10000;
	AudioSource ActionAudio;
	public GameObject knight;

	// Use this for initialization
	void Start () {
		ActionAudio = GetComponent<AudioSource> ();
		ActionAudio.clip = throwingSound;
	}
	
	// Update is called once per frame
	void Update () {
		time -= 1; 
		if (time % 100 == 10)
		{
			Vector3 position= new Vector3(knight.transform.position.x, knight.transform.position.y, knight.transform.position.z);  
			Vector3 startPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 20, gameObject.transform.position.z);

			GameObject snowball= Instantiate (projectile, startPos, Quaternion.identity) as GameObject; 
			snowball.transform.LookAt(position); 
			snowball.GetComponent<Rigidbody>().AddForce(snowball.transform.forward *5000); 
			ActionAudio.Play();
		}
	}

	void OnTriggerEnter(Collider other) {
		Destroy (gameObject);
	}
}
