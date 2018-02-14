using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {
    [Range(0, 10)] public float movementSpd = 5;
    public Animator PlayerAnimator;
    public Animator HairAnimator;

    public float Xaxis;
    public float Yaxis;

    Vector2 previousMove;
    // Use this for initialization
    void Start()
    {
        PlayerAnimator = GetComponent<Animator>();
        previousMove = new Vector2();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        BasicMovement();
    }

    void BasicMovement()
    {
        Yaxis = Input.GetAxis("Vertical");
        Xaxis = Input.GetAxis("Horizontal");

        PlayerAnimator.SetFloat("inputX", Xaxis);
        PlayerAnimator.SetFloat("inputY", Yaxis);
        HairAnimator.SetFloat("inputX", Xaxis);
        HairAnimator.SetFloat("inputY", Yaxis);

        Vector2 moveVector = new Vector2(Xaxis, Yaxis);
        transform.Translate(moveVector * Time.deltaTime * movementSpd);

        if (moveVector == Vector2.zero)
        {
            PlayerAnimator.SetBool("isMoving", false);
            HairAnimator.SetBool("isMoving", false);
        }
        else
        {
            PlayerAnimator.SetBool("isMoving", true);
            HairAnimator.SetBool("isMoving", true);
        }

        if(moveVector.magnitude != 0)
        {
            previousMove = moveVector;
            PlayerAnimator.SetFloat("LastX", previousMove.x);
            PlayerAnimator.SetFloat("LastY", previousMove.y);
            HairAnimator.SetFloat("LastX", previousMove.x);
            HairAnimator.SetFloat("LastY", previousMove.y);
        }
        
    }
}
