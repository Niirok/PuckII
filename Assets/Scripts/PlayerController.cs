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
