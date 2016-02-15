using UnityEngine;
using System.Collections;

public class Moover : MonoBehaviour
{
    private Vector2 lastPlayerPos;
    private Vector2 movement;
    public float speed;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Position Joueur
       // print(player.transform);
        lastPlayerPos.x = player.position.x;
        lastPlayerPos.y = player.position.y;
       // print(lastPlayerPos);
        movement.x = lastPlayerPos.x - GetComponentInParent<Transform>().position.x+1;
        movement.y = lastPlayerPos.y - GetComponentInParent<Transform>().position.y+2;
        GetComponent<Rigidbody2D>().velocity = movement * speed;
    }

    

   /* void FixedUpdate()
    {
        Vector3 direction = new Vector3(transform.position.x - lastPlayerPos.x, transform.position.y - lastPlayerPos.y);
        Ray ray = new Ray(lastPlayerPos, direction);
        RaycastHit hit;
        if (Physics.Raycast(ray, hit, direction.magnitude))
        {
            // Do something if hit
        }

        this.lastPosition = transform.position;
    }*/


    void OnCollisionEnter(Collision collision)
    {
        print("jackpot");
        /*  print(collision.contacts[0]);
          // Debug-draw all contact points and normals
          foreach (ContactPoint contact in collision.contacts)
          {
              Debug.DrawRay(contact.point, contact.normal, Color.white);
          }*/
        Destroy(this);
    }
}
