using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTowardMouse : MonoBehaviour {
    public float rotateSpd = 5f;
    public Transform tTarget;
    public float fRadius = 3f;
    public Transform pivot;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        RotateTowardMouse();
    }
    
    void RotateTowardMouse() //Rotating itself, not around player
    {
        Vector2 playerDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateAngle = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(rotateAngle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSpd * Time.deltaTime);


        /*Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 playerDirection = new Vector2(
            mousePosition.x = transform.position.x,
            mousePosition.y = transform.position.y
            );
        transform.up = playerDirection;*/

    }
}
