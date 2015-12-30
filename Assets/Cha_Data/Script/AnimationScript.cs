using UnityEngine;
using System.Collections;

public class AnimationScript : MonoBehaviour {
	
	public Animation animator; 
	public GameObject knight; 
	// Use this for initialization
	void Start () {
	
		animator = GetComponent<Animation> (); 
	}
	
	// Update is called once per frame
	void Update () {
		toggleAnimations (); 
	}

	void toggleAnimations() {
		if (Input.GetButtonDown ("Vertical")) {
			animator.Play ("Walk"); 
		}
		if (Input.GetButtonDown ("Fire1")) {
			animator.Play ("Attack"); 
		} 
	}

}

