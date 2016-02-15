using UnityEngine;
using System.Collections;

public class ScrollingScriptResume : MonoBehaviour {

	public static ScrollingScriptResume instance;

	public GameObject Foreground2_1;
	public GameObject Foreground2_2;
	public GameObject Foreground2_3;
	public GameObject Foreground2_4;
	public GameObject Foreground2_5;
	public GameObject Foreground2_6;
	public GameObject Foreground2_7;
	public GameObject Foreground2_8;

	public GameObject Background2_1;
	public GameObject Background2_2;
	public GameObject Background2_3;
	public GameObject Background2_4;
	public GameObject Background2_5;
	public GameObject Background2_6;
	public GameObject Background2_7;
	public GameObject Background2_8;
	public GameObject Background2_9;
	public GameObject Background2_10;
	public GameObject Background2_11;
	public GameObject Background2_12;
	public GameObject Background2_13;
	public GameObject Background2_14;

	public Vector2 speedF = new Vector2(2, 2);
	public Vector2 directionF = new Vector2(-1, 0);
	
	public Vector2 speedB = new Vector2(0.1f, 0.1f);
	public Vector2 directionB = new Vector2(-1, 0);

	float last_xposition = 0;

  void Start() {
  instance = this;
  }

	public void Move(float horizontal_input, float xposition) {



	if (last_xposition != xposition) {

	// Mouvement
    Vector3 movementF = new Vector3(
      speedF.x * directionF.x,
      speedF.y * directionF.y,
      0);

    movementF *= Time.deltaTime;
	movementF *= horizontal_input;


	Foreground2_1.transform.Translate(movementF);

	if (xposition >= 10)
		Foreground2_2.transform.Translate(movementF);

	if (xposition >= 40)
		Foreground2_3.transform.Translate(movementF);

	if (xposition >= 60)
		Foreground2_4.transform.Translate(movementF);

	if (xposition >= 70)
	Foreground2_5.transform.Translate(movementF);

	if (xposition >= 140) {
	Foreground2_6.transform.Translate(movementF);
	Foreground2_7.transform.Translate(movementF);
	}

	if (xposition >= 150)
	Foreground2_8.transform.Translate(movementF);


	// Mouvement
    Vector3 movementB = new Vector3(
      speedB.x * directionB.x,
      speedB.y * directionB.y,
      0);

    movementB *= Time.deltaTime;
	movementB *= horizontal_input;


	Background2_1.transform.Translate(movementB);

	Background2_2.transform.Translate(movementB);

	Background2_3.transform.Translate(movementB);

	Background2_4.transform.Translate(movementB);

	Background2_5.transform.Translate(movementB);

	Background2_6.transform.Translate(movementB);
	Background2_7.transform.Translate(movementB);

	if (xposition >= 150) {
	Background2_8.transform.Translate(movementB);

	Background2_9.transform.Translate(movementB);

	Background2_10.transform.Translate(movementB);

	Background2_11.transform.Translate(movementB);

	Background2_12.transform.Translate(movementB);

	Background2_13.transform.Translate(movementB);

	}

	last_xposition = xposition;

	}


}
}
