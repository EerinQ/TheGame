using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpacityChangeWhenBehind : MonoBehaviour {

    public void OnTriggerEnter2D(Collider2D otherCol)
    {
        //Debug.Log("triggered");
        if (otherCol.tag == "Player")
        {
            if (otherCol.transform.position.z > this.transform.position.z)
            {
                //Debug.Log("alpha");
                this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            }
        }
    }

    public void OnTriggerExit2D(Collider2D otherCol)
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }
}
