using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerController : MonoBehaviour {

    public float speed = 10, jumpVelocity = 10;
    public LayerMask playerMask;
    public bool canMoveInAir = true;
    Transform myTrans, tagGround;
    Rigidbody2D myBody;
    bool isGrounded = false;
    AnimatorController myAnim;
    float hInput;

    void Start()
    {
        myBody = this.GetComponent<Rigidbody2D>();
        myTrans = this.transform;
        tagGround = GameObject.Find(this.name + "/tag_ground").transform;
        myAnim = AnimatorController.instance;
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.Linecast(myTrans.position, tagGround.position, playerMask);
        myAnim.UpdateIsGround(isGrounded);

        //isGrounded = true;
        hInput = Input.GetAxisRaw("Horizontal");
        
        myAnim.UpdateSpeed(hInput);
        if (Input.GetButtonDown("Jump")) Jump();
        Move(hInput);
    }

    public void Move(float horizontalInput)
    {
        if (!canMoveInAir && !isGrounded ) return;
        Vector2 moveVel = myBody.velocity;
        moveVel.x = horizontalInput * speed;
        myBody.velocity = moveVel;
    }

    public void Jump()
    {
        if (isGrounded) myBody.velocity += jumpVelocity * Vector2.up;
    }
}
