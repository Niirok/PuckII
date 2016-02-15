using UnityEngine;
using System.Collections;

public class PlanteController : MonoBehaviour {

	public Sprite plante_kawaii;
	public Sprite plante_renversement;
	public Sprite plante_gros;
	public Sprite plante_grand;
	public Sprite planteBook;

	bool isKawaii = false;
	bool isRenversement = false;
	bool isGros = false;
	bool isGrand = false;
	bool isBook = false;

	public static int OnLinePlant = -1;
	public static bool onMove = false;

	Animator myAnim;

	int nb = 0;

	public Sprite choosedPlante;

	void Awake() {
		DontDestroyOnLoad(this);
	}

	// Use this for initialization
	void Start () {
	myAnim = this.gameObject.GetComponent<Animator>();

	changePlante();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {

			// TODO : Animation plante 

			onMove = true;
			myAnim.SetBool("onMove", onMove);
			
			//other.transform.position = new Vector3(-12.91f,18.04f,5f);
			//other.transform.position = new Vector3(205.3f,40.4f,5f);

			//onMove = false;
			myAnim.SetBool("onMove", onMove);

			changePlante();
		}
			
	}

	void changePlante() {

		if (nb < 4) {

		int rand = 0;
		bool trouve = false;

		while(!trouve) {
		rand = Random.Range(0,5);
		if (rand == 0) {
			if(!isKawaii) {
				choosedPlante = plante_kawaii;
				isKawaii = true;
				trouve = true;
				OnLinePlant = 0;
				myAnim.SetInteger("OnLinePlant", OnLinePlant);
			}
		}
		else if (rand == 1) {
			if (!isRenversement) {
				choosedPlante = plante_renversement;
				isRenversement = true;
				trouve = true;
				OnLinePlant = 1;
				myAnim.SetInteger("OnLinePlant", OnLinePlant);
			}
		}
		else if (rand == 2) {
			if (!isGros) {
				choosedPlante = plante_gros;
				isGros = true;
				trouve = true;
				OnLinePlant = 2;
				myAnim.SetInteger("OnLinePlant", OnLinePlant);
			}
		}
		else if (rand == 3) {
			if(!isGrand) {
				choosedPlante = plante_grand;
				isGrand = true;
				trouve = true;
				OnLinePlant = 3;
				myAnim.SetInteger("OnLinePlant", OnLinePlant);
			}
		}
		else if (rand == 4) {
			if (!isBook) {
				choosedPlante = planteBook;
				isBook = true;
				trouve = true;
				OnLinePlant = 4;
				myAnim.SetInteger("OnLinePlant", OnLinePlant);
			}
		}

		}

		this.GetComponent<SpriteRenderer>().sprite = choosedPlante;
		nb ++;
		}
	}
}
