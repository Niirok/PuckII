using UnityEngine;
using System.Collections;
[System.Serializable]
public class BossTriggerController : MonoBehaviour {

    public GameObject boss;
    public bool on = false;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!on)
            {
                Instantiate(boss, new Vector3(200, 40,5), transform.rotation);
                on = true;
            }
        }

    }


}
