using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerController : MonoBehaviour {

    public float speed = 10, jumpVelocity = 10, runCoef = 1.2f;
    public LayerMask playerMask;
    public static PlayerController instance;
    public bool canMoveInAir = true;
    Transform myTrans, tagGround;
    Rigidbody2D myBody;
    bool isGrounded = false;
    AnimatorController myAnim;
    float hInput, runBonus;
    int idleTimer = 0;
    int soundTimer = 0;
    AudioClip[] song;
    int nbSong;
    public AudioClip SoundA;
    public AudioClip SoundZ;
    public AudioClip SoundE;
    public AudioClip SoundR;
    public AudioClip SoundQ;
    public AudioClip SoundS;
    public AudioClip SoundD;
    public AudioClip SoundF;
    bool debugsound;
    bool bossOn;

	public PlanteController plant;
	public Sprite KawaiiPlante;
	public Sprite RenversementPlante;
	public Sprite GrosPlante;
	public Sprite GrandPlante;
	public Sprite BookPlante;

	public ScrollingScriptResume myscrolling;
		
	public Sprite PuckGros;

    void Start()
    {
        myBody = this.GetComponent<Rigidbody2D>();
        myTrans = this.transform;
        tagGround = GameObject.Find(this.name + "/tag_ground").transform;
        myAnim = AnimatorController.instance;
        runBonus = 0;
        instance = this;
        nbSong = 0;
        song = new AudioClip[20];
        bossOn = true;
    }

    public void playSound(AudioClip a)
    {
        if (bossOn)
        {
            SoundManager.instance.PlaySingle(a);
            soundTimer = 40;
            song[nbSong] = a;
            nbSong++;
            if (GameObject.Find("Boss(Clone)")!=null && BossController.instance.beHit())
            {
                
                playAll();
                bossOn = false;
            }
        }
    }

    public void playAll() {
        StartCoroutine("maCoroutine");
    }

    IEnumerator maCoroutine()
    {
        int i = 0;
        while (i < nbSong)
        {
            yield return new WaitForSeconds(1f);
            SoundManager.instance.PlaySingle(song[i]);
            i++;
        }

		//hatchPlant();

    }

    void FixedUpdate()
    {
        if (soundTimer > 0) soundTimer--;
        //SoundManager.instance.CancelInvoke();

        bool soundA = Input.GetKeyDown(KeyCode.A);
        bool soundZ = Input.GetKeyDown(KeyCode.Z);
        bool soundE = Input.GetKeyDown(KeyCode.E);
        bool soundQ = Input.GetKeyDown(KeyCode.Q);
        bool soundS = Input.GetKeyDown(KeyCode.S);
        bool soundD = Input.GetKeyDown(KeyCode.D);
        bool soundF = Input.GetKeyDown(KeyCode.F);
        bool soundR = Input.GetKeyDown(KeyCode.R);

        if (soundA && soundTimer==0) {
            playSound(SoundA);
        }
        if (soundZ && soundTimer == 0)
        {
            playSound(SoundZ);
        }
        if (soundE && soundTimer == 0)
        {
            playSound(SoundE);
        }
        if (soundR && soundTimer == 0)
        {
            playSound(SoundR);
        }
        if (soundQ && soundTimer == 0)
        {
            playSound(SoundQ);
        }
        if (soundS && soundTimer == 0)
        {
            playSound(SoundS);
        }
        if (soundD && soundTimer == 0)
        {
            playSound(SoundD);
        }
        if (soundF && soundTimer == 0)
        {
            playSound(SoundF);
        }


        runBonus = 0;
        if (Input.GetButton("Fire1")) runBonus = runCoef;
        isGrounded = Physics2D.Linecast(myTrans.position, tagGround.position, playerMask);

        myAnim.UpdateIsGround(isGrounded);
        hInput = Input.GetAxisRaw("Horizontal");
        myAnim.UpdateSpeed(hInput);
        if (Input.GetButtonDown("Jump")) Jump();
        Move(hInput);
    }

    public void Move(float horizontalInput)
    {
		
		myscrolling.Move(horizontalInput,myTrans.position.x);

        if (!canMoveInAir && !isGrounded ) return;
        Vector2 moveVel = myBody.velocity;
        moveVel.x = horizontalInput * (speed+ runCoef * runBonus);
        myBody.velocity = moveVel;

        if (hInput == 0 && moveVel.y == 0) {
            idleTimer++;
            if (idleTimer == 240) {

                idleTimer = 0;
            }
        }
    }

    public void Jump()
    {
        if (isGrounded) myBody.velocity += jumpVelocity * Vector2.up;
    }


		void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Plante") {
			changePuck();
		}
	}

	void changePuck() {
	
		this.GetComponent<SpriteRenderer>().sprite = PuckGros;
	
	}

	/*void hatchPlant() {

		if (plant.OnLinePlant == 0) {
			plant.GetComponent<SpriteRenderer>().sprite = KawaiiPlante;
		} else if (plant.OnLinePlant == 1) {
		plant.GetComponent<SpriteRenderer>().sprite = RenversementPlante;
		
		} else if (plant.OnLinePlant == 2) {
		plant.GetComponent<SpriteRenderer>().sprite = GrosPlante;
		} else if (plant.OnLinePlant == 3){
		plant.GetComponent<SpriteRenderer>().sprite = GrandPlante;

		} else if (plant.OnLinePlant == 4) {
		plant.GetComponent<SpriteRenderer>().sprite = BookPlante;
		}
	
	}*/
}
