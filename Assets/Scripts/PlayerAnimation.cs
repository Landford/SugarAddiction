using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
	public GameObject playerImage;
	public Animator playerAnim;

	[Range(0.0f, 1.0f)]
	public float fatLevel;

	private bool isFacingRight;
	private PlayerInput playerInput;
	private PlayerMovement playerMovement;
	private CharacterController characterController;

	private bool canLand;
	//private bool canJump;

	// Use this for initialization
	void Start () {
		characterController =  this.gameObject.GetComponent<CharacterController>();
		playerInput =  this.gameObject.GetComponent<PlayerInput>();
		playerMovement =  this.gameObject.GetComponent<PlayerMovement>();

		isFacingRight = true;
		//canJump = true;
		canLand = false;
	}
	
	// Update is called once per frame
	void Update () {
		//Animations
		if(characterController.isGrounded){
			if(canLand){
				//Landing
				PlayAnimationLanding();
				canLand = false;
			}
		}

		if(playerInput.IsJump()) PlayAnimationJump();

		playerAnim.SetFloat("speedX", playerMovement.GetSpeedX());
		playerAnim.SetFloat("speedY", playerMovement.GetMoveY());
		playerAnim.SetBool("isGrounded", characterController.isGrounded);

		//fatlevel
		playerAnim.Play("Hood_Default_Fat", 2, fatLevel); //2 = FatLayer
	}

	public void PlayerAnimationOrientation(string side){
		Vector3 eulerRight = new Vector3(0,270,0);
		Vector3 eulerLeft = new Vector3(0,90,0);

		if(side == "left"){
			playerImage.transform.eulerAngles = eulerLeft;
			isFacingRight = false;
		}else{
			playerImage.transform.eulerAngles = eulerRight;
			isFacingRight = true;
		}
	}

	public bool IsFacingRight(){
		return isFacingRight;
	}

	public void PlayAnimationJump(){
		playerAnim.SetTrigger("jumping");
	}

	public void PlayAnimationLanding(){
		playerAnim.SetTrigger("landing");
	}

	public void PlayAnimationAttack(){
		playerAnim.SetTrigger("attack");
	}

}
