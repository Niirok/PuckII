using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerController : MonoBehaviour {

    public float speed = 10, jumpVelocity = 10, runCoef = 1.2f;
    public LayerMask playerMask;
    public bool canMoveInAir = true;
    Transform myTrans, tagGround;
    Rigidbody2D myBody;
    bool isGrounded = false;
    AnimatorController myAnim;
    float hInput, runBonus;
    int idleTimer = 0;
    public AudioClip SoundA;
    public AudioClip SoundZ;
    public AudioClip SoundE;
    public AudioClip SoundR;
    public AudioClip SoundQ;
    public AudioClip SoundS;
    public AudioClip SoundD;
    public AudioClip SoundF;
    
    void Start()
    {
        myBody = this.GetComponent<Rigidbody2D>();
        myTrans = this.transform;
        tagGround = GameObject.Find(this.name + "/tag_ground").transform;
        myAnim = AnimatorController.instance;
        runBonus = 0;
    }

    void FixedUpdate()
    {
        bool soundA = Input.GetKeyDown(KeyCode.A);
        bool soundZ = Input.GetKeyDown(KeyCode.Z);
        bool soundE = Input.GetKeyDown(KeyCode.E);
        bool soundQ = Input.GetKeyDown(KeyCode.Q);
        bool soundS = Input.GetKeyDown(KeyCode.S);
        bool soundD = Input.GetKeyDown(KeyCode.D);
        bool soundF = Input.GetKeyDown(KeyCode.F);
        bool soundR = Input.GetKeyDown(KeyCode.R);
        int soundTimer = 0;
        int cd = 2000000;
        bool done = true;

        if (soundA && done && cd !=0) {
            SoundManager.instance.PlaySingle(SoundA);
            soundTimer = cd;
            done = false;
        }
        if (soundZ && done && cd != 0)
        {
            SoundManager.instance.PlaySingle(SoundZ);
            soundTimer = cd;
            done = false;
        }
        if (soundE && done && cd != 0)
        {
            SoundManager.instance.PlaySingle(SoundE);
            soundTimer = cd;
            done = false;
        }
        if (soundR && done && cd != 0)
        {
            SoundManager.instance.PlaySingle(SoundR);
            soundTimer = cd;
            done = false;
        }
        if (soundQ  && done && cd != 0)
        {
            SoundManager.instance.PlaySingle(SoundQ);
            soundTimer = cd;
            done = false;
        }
        if (soundS && done && cd != 0)
        {
            SoundManager.instance.PlaySingle(SoundS);
            soundTimer = cd;
            done = false;
        }
        if (soundD && done && cd != 0)
        {
            SoundManager.instance.PlaySingle(SoundD);
            soundTimer = cd;
            done = false;
        }
        if (soundF && done)
        {
            SoundManager.instance.PlaySingle(SoundF);
            soundTimer = cd;
            done = false;
        }

        soundTimer--;
        print(soundTimer);
        print(done);
        if (soundTimer <= 0)
        {
            soundTimer = 0;
            print(done);
            done = true;
            SoundManager.instance.CancelInvoke();
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
}
