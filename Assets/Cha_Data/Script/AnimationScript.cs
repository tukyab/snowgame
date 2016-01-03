using UnityEngine;
using System.Collections;

public class AnimationScript : MonoBehaviour {
	
	public Animation KnightAnimator; 
	public Animation SlimeAnimator; 
	public GameObject knight; 
	float timer= 500f; 
	// Use this for initialization
	void Start () {
	
		KnightAnimator = GetComponent<Animation> (); 
	}
	
	// Update is called once per frame
	void Update () {
		toggleAnimations (); 
		timer -= 1.0f; 
	}

	void toggleAnimations() {
		if (Input.GetButtonDown ("Vertical")) {
			KnightAnimator.Play ("Walk"); 
		}
		if (Input.GetButtonDown ("Fire1")) {
			KnightAnimator.Play ("Attack"); 
		} 
		if(timer % 10 == 0) {
			SlimeAnimator.Play ("Attack"); 
		}
	}

}

