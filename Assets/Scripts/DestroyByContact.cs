using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Untagged")
        {
            Destroy(gameObject);
        }
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            other.transform.position = new Vector3(5, 10,5);
        }

    }
   

}
