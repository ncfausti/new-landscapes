using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// game code goes here
	public float speed;
	private int count;
	public GUIText countText;
	public GUIText winText;
	void Start(){
		count = 0;
		winText.text = "";
	}

	void Update() {

	}

	// select text and use cmd + ' to search api in web browser 
	// Performed just before performing any physics updates
	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().AddForce (movement * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "PickUp") {
			other.gameObject.SetActive(false);
			count += 1;
			setCountText();
		}
	}

	void setCountText(){
		countText.text = "Count: " + count.ToString ();
		if (count == 11)
			winText.text = "YOU WIN!";
	}

}