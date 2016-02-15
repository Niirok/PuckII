using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {

    //public static BossController instance;
    public int life, cooldown;
    private int cdNow;
    public static BossController instance;
    public GameObject  shot;
    int hitDelay;

    // DONT DESTROY ON LOAD

	void Start () {
        cdNow = 0;
        shoot();
        instance = this;
        hitDelay = 0;
        DontDestroyOnLoad(gameObject);
    }

    public bool alive() {
        return life > 0;
    }
   public bool beHit() {
        if (--life == 0)
        {
            GetComponent<SpriteRenderer>().color = Color.clear;
            DestroyImmediate(this);
            return true;
        }
        else {
            GetComponent<SpriteRenderer>().color = Color.red;
            hitDelay = 20;
            return false;
        }
    }

    void Update () {
            if (--hitDelay == 0) GetComponent<SpriteRenderer>().color = Color.white;
            if (cdNow++ > cooldown)
            {
                shoot();
                cdNow = 0;
            }
    }

    void shoot() {
            float x = transform.position.x;
            float y = transform.position.y;
            Instantiate(shot, new Vector2(x, y + 4.5f), transform.rotation); // Creer tire sur le boss
        }
}
