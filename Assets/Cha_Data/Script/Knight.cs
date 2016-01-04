using UnityEngine;
using System.Collections;

public class Knight : MonoBehaviour {
	
	public Animation KnightAnimator; 
	public GameObject knight; 
	int health = 100;
	// Use this for initialization
	void Start () {
	
		KnightAnimator = GetComponent<Animation> (); 
	}
	
	// Update is called once per frame
	void Update () {
		toggleAnimations (); 
	}

	void toggleAnimations() {
		if (Input.GetButton ("Vertical")) {
			KnightAnimator.Play ("Walk"); 
		} else if (Input.GetButton ("Fire1")) {
			KnightAnimator.Play ("Attack"); 
		} else {
			KnightAnimator.Play ("Wait");
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("snowball")) {
			health -= 1;
			Destroy (other.gameObject);
			KnightAnimator.Play ("Damage");
		}
		if (health == 0) {
			KnightAnimator.Play("Dead");
			Destroy (gameObject);
		}
	}

	void OnGUI() {
		GUIStyle style = new GUIStyle ();
		style.fontSize = 16;
		style.normal.textColor = Color.blue;
		if (health > 0) {
			GUI.Label(new Rect(50, 50, 250, 100), "Health:" + health, style);
		} else {
			GUI.Label(new Rect(50, 50, 250, 100), "Game Over", style);
		}
	}
}

