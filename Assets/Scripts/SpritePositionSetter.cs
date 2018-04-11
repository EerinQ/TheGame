using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritePositionSetter : MonoBehaviour {

    void Awake()
    {
        SetPosition();  
    }

    void Start()
    {
        //set the hair's z -, sothat its on top of player
        if (gameObject.tag == "Hair")
        {
            Debug.Log("111");
           transform.position = new Vector3(transform.position.x, transform.position.y, -0.03f);
        }
    }

    void Update()
        {
            SetPosition();
        }

    void SetPosition()
        {

            if(gameObject.tag == "Front_Back" || gameObject.tag == "Player")//don't set hair here
            {
                Vector3 newPosition = transform.position;
                newPosition.z = transform.position.y;
                if(newPosition.z < -0.03f)
                {
                    newPosition.z = -0.03f;
                    transform.position = newPosition;
                }
                else
                {
                    transform.position = newPosition;
                }
            }
        }
}
