﻿using UnityEngine;
using System.Collections;

public class AnimatorController : MonoBehaviour {

    public static AnimatorController instance;

    Transform myTrans;
    Animator myAnim;
    Vector3 artScaleCache;

	void Start () {
        myTrans = this.transform;
        myAnim = this.gameObject.GetComponent<Animator>();
        instance = this;

        artScaleCache = myTrans.localScale;
	}

    void FlipArt(float currentSpeed) {
        if((currentSpeed >0 && artScaleCache.x == 1) || (currentSpeed <0 && artScaleCache.x == -1)) {
            artScaleCache.x *= -1;
            myTrans.localScale = artScaleCache;
        }
    }

    public void UpdateSpeed(float currentSpeed) {
        myAnim.SetFloat("Speed", currentSpeed);
        FlipArt(currentSpeed);
    }

    public void UpdateIsGround(bool isGrounded) {
        myAnim.SetBool("isGrounded", isGrounded);
    }

	public bool GetBool(string str) {
		return myAnim.GetBool(str);
	}

	void Update () {
	
	}
}
