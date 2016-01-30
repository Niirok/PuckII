using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerController : MonoBehaviour {

	public float speed;
	public float tilt;

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody2D>().velocity = movement * speed;

        /*GetComponent<Rigidbody2D>().position = new Vector3(
            Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, -10, 10),
            0.0f,
            0.0f
		);*/
	}
}
