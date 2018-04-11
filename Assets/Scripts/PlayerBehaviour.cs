using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {
    //Movement
    [Range(0, 10)] public float movementSpd = 2;
    public float Xaxis;
    public float Yaxis;
    public Vector2 previousMove;
    //Animation
    
    //Shooting
    public Transform GunPos;
    public GameObject bullet;
    public float shootSpd = 15;

    void Start()
    {
        previousMove = new Vector2();
    }

    void FixedUpdate()
    {
        BasicMovementandAnim();
        PlayerShooting();
    }

    public void BasicMovementandAnim()
    {
        Yaxis = Input.GetAxis("Vertical");
        Xaxis = Input.GetAxis("Horizontal");

        Vector2 moveVector = new Vector2(Xaxis, Yaxis);
        transform.Translate(moveVector * Time.fixedDeltaTime * movementSpd);
    }

    public void PlayerShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            Vector2 myPos = new Vector2(GunPos.position.x, GunPos.position.y);
            Vector2 direction = target - myPos;
            direction.Normalize();
            Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
            GameObject projectile = (GameObject)Instantiate(bullet, myPos, rotation);
            projectile.GetComponent<Rigidbody2D>().velocity = direction * shootSpd;
        }
    }
}
