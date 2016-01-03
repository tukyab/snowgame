using UnityEngine;
using System.Collections;

public class SoundEffects : MonoBehaviour {
	
	public AudioClip[] audios= new AudioClip[3]; 
	public GameObject knight; 
	public GameObject slime; 
	AudioSource ActionAudio; 
	int timer= 500;
	// Use this for initialization
	void Start () { 
		ActionAudio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		timer -= 1; 

		if (Input.GetButtonDown ("Vertical")) {
			ActionAudio.clip= audios[0]; 
			ActionAudio.Play (); 
		}
		if (Input.GetButtonDown ("Fire1")) {
			ActionAudio.clip= audios[1]; 
			ActionAudio.Play (); 
		}
		/*if (knight.transform.position.x - slime.transform.position.x <= 10  ) {
			ActionAudio.clip= audios[2]; 
			ActionAudio.Play (); 
		} */  // isn't working... it plays every millisecond when i run it and it sounds horrendous. 
	}
}
