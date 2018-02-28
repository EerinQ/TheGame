using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimManager : MonoBehaviour {
    public Animator PlayerAnimator;
    public Animator HairAnimator;
    public GameObject myPlayer;

    float Xaxis;
    float Yaxis;
    PlayerBehaviour myPlayerBehaviour;
    Vector2 previousMove;
    // Use this for initialization
    void Start () {
        myPlayerBehaviour = myPlayer.GetComponent<PlayerBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
        AnimParametersSet();
    }

    void AnimParametersSet()
    {
        Xaxis = myPlayerBehaviour.Xaxis;
        Yaxis = myPlayerBehaviour.Yaxis;
        previousMove = myPlayerBehaviour.previousMove;
        Vector2 moveVector = new Vector2(Xaxis, Yaxis);

        PlayerAnimator.SetFloat("inputX", Xaxis);
        PlayerAnimator.SetFloat("inputY", Yaxis);
        HairAnimator.SetFloat("inputX", Xaxis);
        HairAnimator.SetFloat("inputY", Yaxis);

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

        if (moveVector.magnitude != 0)
        {
            previousMove = moveVector;
            PlayerAnimator.SetFloat("LastX", previousMove.x);
            PlayerAnimator.SetFloat("LastY", previousMove.y);
            HairAnimator.SetFloat("LastX", previousMove.x);
            HairAnimator.SetFloat("LastY", previousMove.y);
        }
    }
}
