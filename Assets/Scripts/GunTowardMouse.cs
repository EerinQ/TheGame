using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTowardMouse : MonoBehaviour {
    public float rotateSpd = 5f;
    public Transform myGun;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        RotateTowardMouse();
        RotateAround();
    }
    
    void RotateTowardMouse() //Rotating itself, not around player
    {
        Vector2 playerDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - myGun.position;
        float rotateAngle = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(rotateAngle, Vector3.forward);
        myGun.rotation = Quaternion.Slerp(myGun.rotation, rotation, rotateSpd * Time.deltaTime);
    }

    void RotateAround()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector3 loodDir = mousePos - transform.position;
        loodDir = loodDir.normalized;
        transform.up = loodDir;
    }
}
